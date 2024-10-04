import { Student } from '@interfaces/interfaces';
import { fetchStudentById } from '@services/services';
import React, { Suspense, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { CircularProgress } from '@mui/material';


const StudentPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [student, setStudent] = useState<Student | null>(null);

    useEffect(() => {
        fetchStudentById(Number(id))
            .then(data => {
                setStudent(data);
            });
    }, []);

    if (!student) {
        return <CircularProgress color="primary" />;
    }

    return (
            <div className="p-4">
            <h1 className="text-2xl font-bold">Информация о студенте</h1>
            <p><strong>Фамилия:</strong> {student.surname}</p>
            <p><strong>Имя:</strong> {student.name}</p>
            <p><strong>Отчество:</strong> {student.patronymic}</p>
        </div>
    );
};

export default StudentPage;