import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from "@mui/material";


export interface CreateEdBookDialogProps {
    open: boolean;
    onClose: () => void;
    // onSubmit, взято из CreateSupplyDialog
}
const CreateEdBookDialog: React.FC<CreateEdBookDialogProps> = ({
    open,
    onClose
}) => {
    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Создать книжку</DialogTitle>
            <DialogContent>
                <TextField
                    autoFocus
                    margin="dense"
                    label="Дата поставки"
                    type="date"
                    name="supplyDate"
                    value={new Date().toISOString().split('T')[0]}
                    fullWidth
                />
                <TextField
                    margin="dense"
                    label="Поставщик"
                    name="supplier"
                    fullWidth
                    required
                />
                <TextField
                    margin="dense"
                    label="Номер счета"
                    name="invoiceNumber"
                    fullWidth
                    required
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">
                    Отмена
                </Button>
                <Button onClick={() => {}} color="primary">
                    Добавить
                </Button>
            </DialogActions>
        </Dialog>
    )
}

export default CreateEdBookDialog;