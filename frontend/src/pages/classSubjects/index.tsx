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

const sampleData = [
    {
        groundId: '1',
        classSubjects: [
            {
                schoolClassId: '1',
                subjects: [
                    {
                        subjectId: '1',
                        subjectName: 'Математика',
                        chapterNames: [
                            { name: 'Алгебра', bookId: '1' },
                            { name: 'Геометрия', bookId: '2' }
                        ]
                    }
                ]
            }
        ]
    }
];

const books = [
    { id: '1', title: 'Учебник по алгебре' },
    { id: '2', title: 'Учебник по геометрии' },
    { id: '3', title: 'Учебник по физике' },
];

const subjects: SubjectResponse[] = [
    {id: '123', name: 'Математика'},
    {id: '123', name: 'Русский'},
    {id: '123', name: 'География'}
]

const ClassSubjectTree: React.FC = () => {
    const [data, setData] = useState(sampleData);
    const [open, setOpen] = useState<{ [key: string]: boolean }>({});

    const handleToggle = (groundId: string) => {
        setOpen(prev => ({ ...prev, [groundId]: !prev[groundId] }));
    };

    const [options, setOptions] = useState<SubjectResponse[]>([]);

    useEffect(() => {
        // Имитация отправки на сервер и получения данных
        setOptions(subjects);
    }, [subjects]);

    const handleSubjectChange = (groundId: string, schoolClassId: string, subjectId: string | undefined, value: string) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: ground.classSubjects.map(subject => {
                            if (subject.schoolClassId === schoolClassId) {
                                return {
                                    ...subject,
                                    subjects: subject.subjects.map(sub => {
                                        if (sub.subjectId === subjectId) {
                                            return { ...sub, subjectName: value };
                                        }
                                        return sub;
                                    })
                                };
                            }
                            return subject;
                        })
                    };
                }
                return ground;
            });
        });
    };

    const addClassSubject = (groundId: string) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: [
                            ...ground.classSubjects,
                            { schoolClassId: `${ground.classSubjects.length + 1}`, subjects: [] }
                        ]
                    };
                }
                return ground;
            });
        });
    };

    const removeClassSubject = (groundId: string, schoolClassId: string) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: ground.classSubjects.filter(subject => subject.schoolClassId !== schoolClassId)
                    };
                }
                return ground;
            });
        });
    };

    const addSubject = (groundId: string, schoolClassId: string) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: ground.classSubjects.map(subject => {
                            if (subject.schoolClassId === schoolClassId) {
                                return {
                                    ...subject,
                                    subjects: [
                                        ...subject.subjects,
                                        { subjectId: `${subject.subjects.length + 1}`, subjectName: '', chapterNames: [] }
                                    ]
                                };
                            }
                            return subject;
                        })
                    };
                }
                return ground;
            });
        });
    };

    const removeSubject = (groundId: string, schoolClassId: string, subjectId: string) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: ground.classSubjects.map(subject => {
                            if (subject.schoolClassId === schoolClassId) {
                                return {
                                    ...subject,
                                    subjects: subject.subjects.filter(sub => sub.subjectId !== subjectId)
                                };
                            }
                            return subject;
                        })
                    };
                }
                return ground;
            });
        });
    };

    const addChapter = (groundId: string, schoolClassId: string, subjectId: string | undefined) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: ground.classSubjects.map(subject => {
                            if (subject.schoolClassId === schoolClassId) {
                                return {
                                    ...subject,
                                    subjects: subject.subjects.map(sub => {
                                        if (sub.subjectId === subjectId) {
                                            return {
                                                ...sub,
                                                chapterNames: [...sub.chapterNames, { name: '', bookId: '' }]
                                            };
                                        }
                                        return sub;
                                    })
                                };
                            }
                            return subject;
                        })
                    };
                }
                return ground;
            });
        });
    };

    const handleChapterChange = (groundId: string, schoolClassId: string, subjectId: string | undefined, chapterIndex: number, value: string, bookId: string) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: ground.classSubjects.map(subject => {
                            if (subject.schoolClassId === schoolClassId) {
                                return {
                                    ...subject,
                                    subjects: subject.subjects.map(sub => {
                                        if (sub.subjectId === subjectId) {
                                            const newChapterNames = [...sub.chapterNames];
                                            newChapterNames[chapterIndex] = { name: value, bookId };
                                            return { ...sub, chapterNames: newChapterNames };
                                        }
                                        return sub;
                                    })
                                };
                            }
                            return subject;
                        })
                    };
                }
                return ground;
            });
        });
    };

    const removeChapter = (groundId: string, schoolClassId: string, subjectId: string | undefined, chapterIndex: number) => {
        setData(prev => {
            return prev.map(ground => {
                if (ground.groundId === groundId) {
                    return {
                        ...ground,
                        classSubjects: ground.classSubjects.map(subject => {
                            if (subject.schoolClassId === schoolClassId) {
                                return {
                                    ...subject,
                                    subjects: subject.subjects.map(sub => {
                                        if (sub.subjectId === subjectId) {
                                            const newChapterNames = [...sub.chapterNames];
                                            newChapterNames.splice(chapterIndex, 1);
                                            return { ...sub, chapterNames: newChapterNames };
                                        }
                                        return sub;
                                    })
                                };
                            }
                            return subject;
                        })
                    };
                }
                return ground;
            });
        });
    };

    return (
        <Box>
            <Typography variant="h4">Структура классов и предметов</Typography>
            {data.map(ground => (
                <Box key={ground.groundId} mb={2} sx={{ border: '1px solid #ccc', borderRadius: '4px', padding: '16px' }}>
                    <Typography variant="h5" onClick={() => handleToggle(ground.groundId)}>
                        {open[ground.groundId] ? <ExpandLessIcon /> : <ExpandMoreIcon />}
                        Ground ID: {ground.groundId}
                    </Typography>
                    <Collapse in={open[ground.groundId]}>
                        <List>
                            {ground.classSubjects.map(classSubject => (
                                <List key={classSubject.schoolClassId}>
                                    <ListItem>
                                        <ListItemText primary={`Class ID: ${classSubject.schoolClassId}`} />
                                        <IconButton onClick={() => removeClassSubject(ground.groundId, classSubject.schoolClassId)}>
                                            <DeleteIcon />
                                        </IconButton>
                                        <IconButton onClick={() => addSubject(ground.groundId, classSubject.schoolClassId)}>
                                            <AddIcon />
                                        </IconButton>
                                    </ListItem>
                                    <List>
                                        {classSubject.subjects.map(subject => (
                                            <ListItem key={subject.subjectId}>
                                                <Autocomplete
                                                    options={options}
                                                    getOptionLabel={(option) => option.name}
                                                    renderInput={(params) => (
                                                        <TextField
                                                        {...params}
                                                        // label={label}
                                                        // value={option.name}
                                                        // onChange={onChange}
                                                        // sx={sx}
                                                        />
                                                    )}
                                                />
                                                <IconButton onClick={() => removeSubject(ground.groundId, classSubject.schoolClassId, subject.subjectId)}>
                                                    <DeleteIcon />
                                                </IconButton>
                                                <IconButton onClick={() => addChapter(ground.groundId, classSubject.schoolClassId, subject.subjectId)}>
                                                    <AddIcon />
                                                </IconButton>
                                                <List>
                                                    {subject.chapterNames.map((chapter, index) => (
                                                        <ListItem key={index}>
                                                            <TextField
                                                                label={`Глава ${index + 1}`}
                                                                value={chapter.name}
                                                                onChange={(e) => handleChapterChange(ground.groundId, classSubject.schoolClassId, subject.subjectId, index, e.target.value, chapter.bookId)}
                                                                sx={{ width: '300px' }}
                                                            />
                                                            <Autocomplete
                                                                options={books}
                                                                getOptionLabel={(option) => option.title}
                                                                onChange={(event, newValue) => {
                                                                    handleChapterChange(ground.groundId, classSubject.schoolClassId, subject.subjectId, index, chapter.name, newValue ? newValue.id : '');
                                                                }}
                                                                renderInput={(params) => (
                                                                    <TextField {...params} label="Выбрать книгу" variant="outlined" />
                                                                )}
                                                                value={books.find(book => book.id === chapter.bookId) || null}
                                                                sx={{ width: '300px', marginLeft: '16px' }}
                                                            />
                                                            <IconButton onClick={() => removeChapter(ground.groundId, classSubject.schoolClassId, subject.subjectId, index)}>
                                                                <DeleteIcon />
                                                            </IconButton>
                                                        </ListItem>
                                                    ))}
                                                </List>
                                            </ListItem>
                                        ))}
                                    </List>
                                </List>
                            ))}
                        </List>
                    </Collapse>
                </Box>
            ))}
            <Button variant="contained" onClick={() => console.log(data)}>Сохранить изменения</Button>
        </Box>
    );
};

export default ClassSubjectTree;
