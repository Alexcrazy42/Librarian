import React, { useState } from 'react';
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogContentText,
    DialogTitle,
    TextField,
    Button,
} from '@mui/material';

export interface CreateSupplyDialogProps {
    open: boolean;
    onClose: () => void;
    onSubmit: (supplyData: {
        supplyDate: Date;
        supplier: string;
        invoiceNumber: string;
        groundId: string;
    }) => void;
}

const CreateSupplyDialog: React.FC<CreateSupplyDialogProps> = ({
    open,
    onClose,
    onSubmit,
}) => {
    const [newSupply, setNewSupply] = useState({
        supplyDate: new Date(),
        supplier: '',
        invoiceNumber: '',
        groundId: '',
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setNewSupply((prev) => ({
            ...prev,
            [name]: name === 'supplyDate' ? new Date(value) : value,
        }));
    };

    const handleSubmit = () => {
        onSubmit(newSupply);
        // Reset state
        setNewSupply({
            supplyDate: new Date(),
            supplier: '',
            invoiceNumber: '',
            groundId: '',
        });
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Создать новую поставку</DialogTitle>
            <DialogContent>
                <DialogContentText>
                    Пожалуйста, заполните информацию о новой поставке.
                </DialogContentText>
                <TextField
                    autoFocus
                    margin="dense"
                    label="Дата поставки"
                    type="date"
                    name="supplyDate"
                    value={newSupply.supplyDate.toISOString().split('T')[0]}
                    onChange={handleChange}
                    fullWidth
                />
                <TextField
                    margin="dense"
                    label="Поставщик"
                    name="supplier"
                    value={newSupply.supplier}
                    onChange={handleChange}
                    fullWidth
                    required
                />
                <TextField
                    margin="dense"
                    label="Номер счета"
                    name="invoiceNumber"
                    value={newSupply.invoiceNumber}
                    onChange={handleChange}
                    fullWidth
                    required
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">
                    Отмена
                </Button>
                <Button onClick={handleSubmit} color="primary">
                    Добавить
                </Button>
            </DialogActions>
        </Dialog>
    );
};

export default CreateSupplyDialog;