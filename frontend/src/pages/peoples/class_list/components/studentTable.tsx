import React from 'react';
import { Student } from '@interfaces/interfaces';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
} from '@mui/material';
import { useNavigate } from 'react-router-dom';

interface StudentTableProps {
    students: Student[];
}

const StudentTable: React.FC<StudentTableProps> = ({ students }) => {
    const navigate = useNavigate();


    const onRowClick = (student: Student) => {
        navigate(`/student/${student.id}`)
    }

    return (
        <TableContainer component={Paper}>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Фамилия</TableCell>
                        <TableCell>Имя</TableCell>
                        <TableCell>Отчество</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {students.map((student, index) => (
                        <TableRow 
                            key={index}
                            onClick={() => onRowClick(student)}
                            sx={{
                                cursor: 'pointer',
                                '&:hover': {
                                    backgroundColor: '#f5f5f5'
                                },
                            }}
                        >
                            <TableCell>{student.surname}</TableCell>
                            <TableCell>{student.name}</TableCell>
                            <TableCell>{student.patronymic}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default StudentTable;