import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { Student } from "@interfaces/interfaces";
import StudentTable from "./components/studentTable";
import { fetchStudentsByClassId } from "@services/services";
import { Box, Button, Dialog, DialogActions, DialogContent, DialogTitle, IconButton, TextField, Tooltip, Typography } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import AddIcon from '@mui/icons-material/Add'

const ClassList: React.FC = () => {
    const { id } = useParams();
    const [students, setStudents] = useState<Student[]>([]);
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


    useEffect(() => {
        fetchStudentsByClassId(Number(id))
            .then(data => {
                setStudents(data);
            });
    }, [id]);

    const [initField1, setInitField1] = useState<number>(1);
    const [initField2, setInitField2] = useState('а');
    const [field1, setField1] = useState<number>(1);
    const [field2, setField2] = useState('а');

    const isDirty = field1 != initField1 || field2 != initField2;

    const handleField1Change = (event) => {
        setField1(event.target.value);
    };

    const handleField2Change = (event) => {
        setField2(event.target.value);
    };

    const handleSave = () => {

        setTimeout(() => {
        }, 1000);
    };


    const [addStudentDialogOpen, setAddStudentDialogOpen] = useState<boolean>(false);
    const handleAddClick = () => {
        setAddStudentDialogOpen(true);
    }
    
    return(
        <>
            <div className="p-4">
                <Box className="flex" gap={2}>
                    <TextField
                        type="number"
                        label="Номер"
                        value={field1}
                        onChange={handleField1Change}
                        variant="outlined"
                    />
                    <TextField
                        label="Класс"
                        value={field2}
                        onChange={handleField2Change}
                        variant="outlined"
                    />
                    {isDirty ? 
                        <Button 
                            variant="contained" 
                            color="primary" 
                            onClick={handleSave}
                        >
                            Сохранить
                        </Button>
                        : null
                        
                    }
                    
                </Box>
                

                <Box display="flex" justifyContent="space-between" alignItems="center" p={2}>
                    <span></span>
                    <IconButton onClick={handleAddClick} color="primary">
                        <AddIcon />
                    </IconButton>
                </Box>


                <StudentTable students={students} />



                <Box display="flex" justifyContent="flex-end" mb={2}>
                    <Tooltip
                        title={!conditionsMet ? "Условия для удаления не выполнены" : ""}
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
                

                <Dialog
                    open={addStudentDialogOpen}
                    onClose={() => setAddStudentDialogOpen(false)}
                >
                    <DialogTitle>Добавление ученика</DialogTitle>
                    <DialogContent>
                        
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={() => setAddStudentDialogOpen(false)} color="primary">
                            Отмена
                        </Button>
                        <Button onClick={handleConfirmDelete} color="secondary">
                            Добавить
                        </Button>
                    </DialogActions>
                </Dialog>
            </div>
        </>
    )
}

export default ClassList;