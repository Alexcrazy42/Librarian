import { Classroom, Student } from '@interfaces/interfaces';
import { fetchClassById, fetchStudentById } from '@services/services';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Box, Button, Card, CardContent, CircularProgress, Dialog, DialogActions, DialogContent, DialogTitle, Tooltip, Typography } from '@mui/material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import StudentInfo from './components/studentInfo';
import EducationalBookRents from './components/educationalBookRents';
import FictionBookRents from './components/fictionBookRents';
import DeleteIcon from '@mui/icons-material/Delete';
import AddIcon from '@mui/icons-material/Add'


const StudentPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [student, setStudent] = useState<Student | null>(null);
    const [classroom, setClassroom] = useState<Classroom | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        fetchStudentById(Number(id))
            .then(student => {
                setStudent(student);
                return fetchClassById(Number(student.classId));
            })
            .then(classData => {
                setClassroom(classData);
            });
    }, []);

    const handleBackToClassList = () => {
        navigate(`/class/${student.classId}`);
    };

    const [openDialog, setOpenDialog] = useState(false);
    const [conditionsMet, setConditionsMet] = useState(false);
    const [tooltipOpen, setTooltipOpen] = useState(false);

    const handleDeleteClick = () => {
        setOpenDialog(true);
    };

    const handleCloseDialog = () => {
        setOpenDialog(false);
    };

    const handleConfirmDelete = () => {
        // Логика для удаления класса
        handleCloseDialog();
    };

    if (!student) {
        return <CircularProgress></CircularProgress>;
    }

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

            <Box display="flex" justifyContent="flex-end" mb={2}>
                    <Tooltip
                        title={!conditionsMet ? "Нельзя удалить, пока не вернет все долги" : ""}
                        arrow
                        placement="top"
                        open={tooltipOpen}
                    >   
                        <span
                            onMouseEnter={() =>  !conditionsMet && setTooltipOpen(true)}
                            onMouseLeave={() => setTooltipOpen(false)}
                        >
                            <Button 
                                    variant="outlined" 
                                    color="secondary" 
                                    startIcon={<DeleteIcon />} 
                                    onClick={handleDeleteClick}
                                    disabled={!conditionsMet} 
                                >
                                    Удалить класс
                                </Button>
                            </span>  
                    </Tooltip>
            </Box>


            <Dialog
                    open={openDialog}
                    onClose={handleCloseDialog}
                >
                    <DialogTitle>Подтверждение удаления</DialogTitle>
                    <DialogContent>
                        Вы уверены, что хотите удалить этот класс?
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={handleCloseDialog} color="primary">
                            Отмена
                        </Button>
                        <Button onClick={handleConfirmDelete} color="secondary">
                            Удалить
                        </Button>
                    </DialogActions>
            </Dialog>
                
        </>
    );
};

export default StudentPage;