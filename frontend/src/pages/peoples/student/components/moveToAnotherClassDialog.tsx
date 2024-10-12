import { Button, Dialog, DialogActions, DialogContent, DialogTitle, List, ListItem, ListItemText, Skeleton } from "@mui/material";
import { Classroom } from '@interfaces/interfaces';
import { useEffect, useState } from "react";
import { fetchClassroomsAsync } from "@services/services";

const MoveToAnotherClassDialog: React.FC<{ open: boolean; onClose: () => void; onSubmit: () => void; }> = ({ open, onClose, onSubmit }) => {
    const [classrooms, setClassrooms] = useState<Classroom[]>([]);
    const [selectedClassroomId, setSelectedClassroomId] = useState<number>();


    useEffect(() => {
        fetchClassroomsAsync()
            .then(data => {
            setClassrooms(data);
            });
    }, []);

    function onClassSelect(classroom: Classroom) {
        setSelectedClassroomId(classroom.id);
    }

    return (
        <Dialog open={open} onClose={onClose}>
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
                        classrooms.map((classroom) => (
                            <ListItem 
                                button
                                key={classroom.id} 
                                onClick={() => onClassSelect(classroom)}
                                selected={classroom.id === selectedClassroomId}
                            >
                                <ListItemText primary={`${classroom.number} ${classroom.name}`} />
                            </ListItem>
                        ))
                    )}
                </List>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">Отмена</Button>
                <Button onClick={onSubmit} color="primary">Перенести</Button>
            </DialogActions>
        </Dialog>
    )
}

export default MoveToAnotherClassDialog;