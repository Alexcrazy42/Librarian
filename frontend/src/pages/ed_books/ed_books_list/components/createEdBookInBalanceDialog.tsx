import { Button, Dialog, DialogActions, DialogContent, DialogTitle } from "@mui/material";

const CreateEdBookInBalanceDialog: React.FC<{ open: boolean; onClose: () => void; }> = ({ open, onClose }) => {
    const handleSubmit = () => {
        onClose();
    };
    
    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Создать книжку</DialogTitle>
            <DialogContent>
                
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">Отмена</Button>
                <Button onClick={handleSubmit} color="primary">Добавить</Button>
            </DialogActions>
        </Dialog>
    );
}

export default CreateEdBookInBalanceDialog;