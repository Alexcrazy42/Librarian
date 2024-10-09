import React, { useState } from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, TablePagination } from '@mui/material';
import { EdBookInBalanceResponse } from '@interfaces/responses/edBooksResponses';


interface EdBookTableProps {
    data: EdBookInBalanceResponse[];
}


const EdBookTable: React.FC<EdBookTableProps> = ({ data }) => {
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);
    
    const handleChangePage = (event: unknown, newPage: number) => {
        setPage(newPage);
    };
    
    const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
        setRowsPerPage(+event.target.value);
        setPage(0);
    };
    
    return (
        <div className="p-4">
        <TableContainer component={Paper}>
            <Table>
            <TableHead>
                <TableRow>
                <TableCell>Название</TableCell>
                <TableCell>Серия издания</TableCell>
                <TableCell>Язык</TableCell>
                <TableCell>Уровень</TableCell>
                <TableCell>Назначение</TableCell>
                <TableCell>Глава</TableCell>
                <TableCell>Начальный класс</TableCell>
                <TableCell>Конечный класс</TableCell>
                <TableCell>Цена</TableCell>
                <TableCell>Состояние</TableCell>
                <TableCell>Год</TableCell>
                <TableCell>Примечание</TableCell>
                <TableCell>Количество</TableCell>
                <TableCell>Общее количество</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {data.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((row) => (
                <TableRow key={row.id}>
                    <TableCell>{row.baseEdBook.title}</TableCell>
                    <TableCell>{row.baseEdBook.publishingSeries}</TableCell>
                    <TableCell>{row.baseEdBook.language}</TableCell>
                    <TableCell>{row.baseEdBook.level}</TableCell>
                    <TableCell>{row.baseEdBook.appointment}</TableCell>
                    <TableCell>{row.baseEdBook.chapter}</TableCell>
                    <TableCell>{row.baseEdBook.startClass}</TableCell>
                    <TableCell>{row.baseEdBook.endClass}</TableCell>
                    <TableCell>{row.price}</TableCell>
                    <TableCell>{row.condition}</TableCell>
                    <TableCell>{row.year}</TableCell>
                    <TableCell>{row.note}</TableCell>
                    <TableCell>{row.inPlaceCount}</TableCell>
                    <TableCell>{row.totalCount}</TableCell>
                </TableRow>
                ))}
            </TableBody>
            </Table>
        </TableContainer>
        <TablePagination
            rowsPerPageOptions={[5, 10, 25]}
            component="div"
            count={data.length}
            rowsPerPage={rowsPerPage}
            page={page}
            onPageChange={handleChangePage}
            onRowsPerPageChange={handleChangeRowsPerPage}
        />
        </div>
    );
};

export default EdBookTable;