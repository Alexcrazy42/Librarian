import React, { useEffect, useState } from 'react';
import {
    Box,
    Typography,
    TextField,
    Button,
    IconButton,
    List,
    ListItem,
    ListItemText,
    Collapse,
    Autocomplete,
} from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import ExpandLessIcon from '@mui/icons-material/ExpandLess';
import AddIcon from '@mui/icons-material/Add';
import DeleteIcon from '@mui/icons-material/Delete';
import { SubjectResponse } from '@interfaces/responses/subjectResponses';
import { Appointment, Language, Level } from '@interfaces/interfaces';
import EdBooksInBalanceToChapterDialog from './components/edBooksInBalanceToChapterDialog';
import AttachBaseEdBookToChapterDialog from './components/attachBaseEdBookToChapterDialog';
import { ClassSubjectDto } from '@interfaces/responses/classSubjectResponses';


const mockData: ClassSubjectDto[] = [
    {
        schoolClassId: '1',
        number: 1,
        name: 'A',
        subjects: [
            {
                id: '1',
                subjectId: '1',
                name: 'Математика',
                chapters: [
                    {
                        id: '1',
                        title: 'Математика 1 часть',
                        edBook: null
                    },
                    {
                        id: '2',
                        title: 'Математика 2 часть',
                        edBook: {
                            id: '1',
                            title: "Introduction to Programming",
                            publishingSeries: 101,
                            language: Language.English,
                            level: Level.Advanced,
                            appointment: Appointment.Allowance,
                            chapter: 1,
                            startClass: 1,
                            endClass: 10
                        }
                    }
                ]
            }
        ]
    },
    {
        schoolClassId: '2',
        number: 2,
        name: 'А',
        subjects: [
            {
                id: '14',
                subjectId: '1',
                name: 'Математика',
                chapters: [
                    {
                        id: '11',
                        title: 'Математика 1 часть',
                        edBook: null
                    },
                    {
                        id: '21',
                        title: 'Математика 2 часть',
                        edBook: {
                            id: '1',
                            title: "Introduction to Programming",
                            publishingSeries: 101,
                            language: Language.English,
                            level: Level.Advanced,
                            appointment: Appointment.Allowance,
                            chapter: 1,
                            startClass: 1,
                            endClass: 10
                        }
                    }
                ]
            }
        ]
    }
]

const allSubjects: SubjectResponse[] = [
    {id: '1', name: 'Математика'},
    {id: '2', name: 'Русский язык'},
    {id: '3', name: 'География'},
    {id: '4', name: 'История'},
    {id: '5', name: 'Физика'},
]

const ClassSubjectTree: React.FC = () => {
    const [data, setData] = useState(mockData);
    const [open, setOpen] = useState<{ [key: string]: boolean }>({});
    const [edBooksToChapterDialogOpen, setEdBooksToChapterDialogOpen] = useState<boolean>(false);
    const [attachBaseEdBookToChapterDialogOpen, setAttachBaseEdBookToChapterDialogOpen] = useState<boolean>(false);
    const [subjects, setSubjects] = useState<SubjectResponse[]>([]);
    const [subjectSearchTerm, setSubjectSearchTerm] = useState('');
    const [subjectLoading, setSubjectLoading] = useState(false);

    const handleToggle = (id: string) => {
        setOpen(prev => ({ ...prev, [id]: !prev[id] }));
    };

    const fetchSubjects = async(term: string) => {
        setSubjectLoading(true);
            const subjects = await new Promise<SubjectResponse[]>((resolve) => {
                setTimeout(() => {
                    resolve(allSubjects.filter(subject => subject.name.toLowerCase().includes(term.toLowerCase())));
                }, 500);
            });

            setSubjects(subjects);
            setSubjectLoading(false);
    }

    useEffect(() => {
        setSubjects(subjects);
    }, [subjects])

    useEffect(() => {
        if (subjectSearchTerm.length >= 2) {
            fetchSubjects(subjectSearchTerm);
        } else {
            setSubjects([]);
        }

    }, [subjectSearchTerm])

    return (
        <>
            <Box>
                <Typography variant="h4">Структура классов и предметов</Typography>
                {/* Классы */}
                {data.map(clas => (
                    <Box>
                        <Typography variant="h5" onClick={() => handleToggle(clas.schoolClassId)}>
                            {open[clas.schoolClassId] ? <ExpandLessIcon /> : <ExpandMoreIcon />}
                            {clas.number}{clas.name}
                        </Typography>
                        <Collapse in={open[clas.schoolClassId]}>
                            <List>
                                {/* Предметы на класс */}
                                {clas.subjects.map(subject => (
                                    <ListItem key={subject.id}>
                                        <Autocomplete
                                            options={subjects}
                                            value={subject}
                                            getOptionLabel={(subject) => subject.name}
                                            loading={subjectLoading}
                                            onInputChange={(event, value) => setSubjectSearchTerm(value)}
                                            onChange={(event, value) => () => {}}
                                            renderInput={(params) => (
                                                <TextField {...params} label="Предмет" margin="dense" fullWidth required />
                                            )}
                                            style={{ width: '400px' }}
                                        />

                                    <IconButton>
                                        <DeleteIcon />
                                    </IconButton>
                                    
                                    <IconButton>
                                        <AddIcon />
                                    </IconButton>

                                    <List>
                                        {/* Главы на предметы */}
                                        {subject.chapters.map(chapter => (
                                            <ListItem key={chapter.id}>
                                                <TextField
                                                    value={chapter.title}
                                                />

                                                <Box sx={{ mx: 2 }} />

                                                {chapter.edBook != null ? (
                                                    <div>
                                                        {`${chapter.edBook.title}: с ${chapter.edBook.startClass} по ${chapter.edBook.endClass} классы, часть: ${chapter.edBook.chapter}`}
                                                        <Box sx={{ mx: 2 }} />
                                                        <Button variant="contained" onClick={() => setEdBooksToChapterDialogOpen(true)}>Посмотреть книги на балансе</Button>
                                                    </div>
                                                    
                                                ) : (
                                                    <Button variant="contained" startIcon={<AddIcon />} onClick={() => setAttachBaseEdBookToChapterDialogOpen(true)}>
                                                        Прикрепить
                                                    </Button>
                                                )}
                                            </ListItem>
                                        ))}
                                    </List>
                                    </ListItem>
                                ))}
                                
                            </List>
                        </Collapse>
                    </Box>
                ))}
                <Button variant="contained" onClick={() => console.log(data)}>Сохранить изменения</Button>
            </Box>

            <EdBooksInBalanceToChapterDialog open={edBooksToChapterDialogOpen} onClose={() => setEdBooksToChapterDialogOpen(false)}/>

            <AttachBaseEdBookToChapterDialog open={attachBaseEdBookToChapterDialogOpen} onClose={() => setAttachBaseEdBookToChapterDialogOpen(false)} onSubmit={()=>{}} />
        </>
    );
};

export default ClassSubjectTree;
