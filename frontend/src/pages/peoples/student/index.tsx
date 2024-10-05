import { Classroom, Student } from '@interfaces/interfaces';
import { fetchClassById, fetchStudentById } from '@services/services';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Button, Card, CardContent, CircularProgress, Typography } from '@mui/material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import StudentInfo from './components/studentInfo';
import EducationalBookRents from './components/educationalBookRents';
import FictionBookRents from './components/fictionBookRents';


const StudentPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [student, setStudent] = useState<Student | null>(null);
    const [classroom, setClassroom] = useState<Classroom | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        fetchStudentById(Number(id))
            .then(data => {
                setStudent(data);
                return fetchClassById(Number(data.classId));
            })
            .then(classData => {
                setClassroom(classData);
            });

        
    }, []);

    const handleBackToClassList = () => {
        navigate(`/class/${student.classId}`);
    };


    return (
        <>
            <Button
                onClick={handleBackToClassList}
                variant="contained"
                color="primary"
                className="mt-4"
                startIcon={<ArrowBackIcon />}
                sx={{ paddingLeft: 1, paddingRight: 0 }}
            />

            <StudentInfo student={student} classroom={classroom}></StudentInfo>

            <EducationalBookRents></EducationalBookRents>

            <FictionBookRents></FictionBookRents>
        </>
    );
};

export default StudentPage;