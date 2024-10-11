import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from "@mui/material";

const CreateClassDialog: React.FC<{ open: boolean; onClose: () => void; }> = ({ open, onClose }) => {
    const handleSubmit = () => {
        console.log(1);
        onClose();
    };
    
    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Создать класс</DialogTitle>
            <DialogContent>
                <TextField>

                </TextField>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">Отмена</Button>
                <Button onClick={handleSubmit} color="primary">Добавить</Button>
            </DialogActions>
        </Dialog>
    )
}

export default CreateClassDialog;