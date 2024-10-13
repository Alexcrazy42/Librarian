import { Alert, Button, Dialog, DialogActions, DialogContent, DialogTitle, List, ListItem, ListItemText, Skeleton } from "@mui/material";
import { Classroom } from '@interfaces/interfaces';
import { useEffect, useState } from "react";
import { fetchClassroomsAsync } from "@services/services";

const MoveToAnotherClassDialog: React.FC<{ open: boolean; onClose: () => void; }> = ({ open, onClose }) => {
    const [classrooms, setClassrooms] = useState<Classroom[]>([]);
    const [selectedClassroomId, setSelectedClassroomId] = useState<number | null>(null);
    const [showSuccessMoveAlert, setShowSuccessMoveAlert] = useState(false);
    const [showNotSelectedClassAlert, setShowNotSelectedClassAlert] = useState(false);

    useEffect(() => {
        fetchClassroomsAsync()
            .then(classrooms => {
                setClassrooms(classrooms);
            });
    }, []);

    function onClassSelect(classroom: Classroom) {
        setSelectedClassroomId(classroom.id);
    }

    function moveToAnotherClassOnClose() {
        onClose();
        setSelectedClassroomId(null);
    }

    const moveToAnotherClassOnSubmit = () => {
        if (selectedClassroomId === null)
        {
            setShowNotSelectedClassAlert(true);
        } else {
            setTimeout(() => {
                onClose();
                setSelectedClassroomId(null);
                setShowSuccessMoveAlert(true);
            }, 1000);
        }
        
    };

    useEffect(() => {
        if (showSuccessMoveAlert) {
            console.log('showAlert')
            const timer = setTimeout(() => {
                setShowSuccessMoveAlert(false);
            }, 3000);
            return () => clearTimeout(timer);
        }
    }, [showSuccessMoveAlert]);

    useEffect(() => {
        if (showNotSelectedClassAlert) {
            const timer = setTimeout(() => {
                setShowNotSelectedClassAlert(false);
            }, 3000);
            return () => clearTimeout(timer);
        }
    }, [showNotSelectedClassAlert]);

    return (
        <>
            <Dialog 
                open={open} 
                onClose={onClose}
                sx={{zIndex:1000}}
            >
                <DialogTitle>Перенос ученика в другой класс</DialogTitle>
                <DialogContent>
                    <List>
                        {classrooms.length === 0 ? (
                            Array.from({ length: 5 }).map((_, index) => (
                                <ListItem key={index}>
                                    <ListItemText primary={<Skeleton width="200px" />} />
                                </ListItem>
                            ))
                            ) : (
                                <>
                                    {classrooms.map((classroom) => (
                                        <ListItem 
                                            button
                                            key={classroom.id}
                                            onClick={() => onClassSelect(classroom)}
                                            selected={selectedClassroomId === classroom.id}
                                            style={{ backgroundColor: selectedClassroomId === classroom.id ? 'rgba(0, 0, 255, 0.2)' : 'transparent' }}
                                        >
                                            <ListItemText primary={`${classroom.number} ${classroom.name}`} />
                                        </ListItem>
                                    ))}
                                </>
                            )}
                    </List>
                </DialogContent>
                <DialogActions>
                    <Button onClick={moveToAnotherClassOnClose} color="primary">Отмена</Button>
                    <Button onClick={moveToAnotherClassOnSubmit} color="primary">Перенести</Button>
                </DialogActions>
            </Dialog>

            {showSuccessMoveAlert && (
                <Alert
                    severity="success"
                    onClose={() => setShowSuccessMoveAlert(false)}
                    sx={{ position: 'fixed', top: '10%', right: '0%', transform: 'translate(-50%, -50%)', zIndex : 1200 }}
                >
                    Ученик успешно перенесен в другой класс!
                </Alert>
            )}


            {showNotSelectedClassAlert && (
                <Alert
                    severity="error"
                    onClose={() => setShowNotSelectedClassAlert(false)}
                    sx={{ position: 'fixed', top: '10%', right: '0%', transform: 'translate(-50%, -50%)', zIndex : 1200 }}
                >
                    Не выбран класс
                </Alert>
            )}
            
        </>
    )
}

export default MoveToAnotherClassDialog;