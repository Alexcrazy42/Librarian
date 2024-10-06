import React, { useState } from 'react';
import {
    Button,
    Accordion,
    AccordionSummary,
    AccordionDetails,
    Typography,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Grid,
    Box,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import CreateSupplyDialog from './components/create_supply_dialog';
import SupplyCard from './components/supply_card';

export interface CreateBookSupplyRequest {
    supplyDate: Date;
    supplier: string;
    invoiceNumber: string;
    groundId: string;
}

export interface Book {
    title: string;
    author: string;
    isbn: string;
}

const SupplyPage = () => {
    const [supplies, setSupplies] = useState<CreateBookSupplyRequest[]>([]);
    const [books, setBooks] = useState<{ [key: number]: Book[] }>({});
    const [open, setOpen] = useState(false);

    const handleAddSupply = (supplyData: CreateBookSupplyRequest) => {
        setSupplies((prev) => [...prev, supplyData]);
    };

    const handleClickOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    return (
        <div className="p-5">
            <h1 className="text-2xl font-bold mb-4 text-center">Список поставок</h1>

            <Box display="flex" justifyContent="flex-end" alignItems="center" mt={2} mb={2}>
                <Button
                    variant="contained"
                    color="success"
                    onClick={handleClickOpen}
                    startIcon={<AddIcon />}
                    style={{ marginLeft: '16px', minWidth: '40px' }}
                >
                    
                </Button>
            </Box>

            
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Дата поставки</TableCell>
                        <TableCell>Поставщик</TableCell>
                        <TableCell>Номер</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {supplies.map((supply, index) => (
                        <TableRow>
                            <TableCell>{supply.supplyDate.toUTCString().split('T')[0]}</TableCell>
                            <TableCell>{supply.supplier}</TableCell>
                            <TableCell>{supply.invoiceNumber}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>

            <CreateSupplyDialog
                open={open}
                onClose={handleClose}
                onSubmit={handleAddSupply}
            />
        </div>
    );
}

export default SupplyPage;
