import React, { useState, useEffect } from 'react';
import {
    Dialog,
    DialogTitle,
    DialogContent,
    TextField,
    DialogActions,
    Button,
    Autocomplete,
    Chip,
    Box,
    CircularProgress,
    IconButton,
} from '@mui/material';
import { Appointment, Language, Level } from '@interfaces/interfaces';
import AddIcon from '@mui/icons-material/Add';

interface Author {
    id: string;
    fullName: string;
}

interface Editor {
    id: string;
    fullName: string;
}

interface Subject {
    id: string;
    name: string;
}

interface CreateBaseEdBookRequest {
    authorIds: string[];
    editorId: string;
    title: string;
    publishingPlaceId: string;
    publishingHouseId: string;
    publishingSeries: number;
    language: Language;
    level: Level;
    appointment: Appointment;
    chapter: number;
    subjectId: string;
    startClass: number;
    endClass: number;
    leaveFromFederalBooksListAt: Date;
}

const CreateBaseEdBookDialog: React.FC<{ open: boolean; onClose: () => void; onSubmit: () => void; }> = ({ open, onClose, onSubmit }) => {
    const [formData, setFormData] = useState<CreateBaseEdBookRequest>({
        authorIds: [],
        editorId: '',
        title: '',
        publishingPlaceId: '',
        publishingHouseId: '',
        publishingSeries: 0,
        language: {} as Language,
        level: {} as Level,
        appointment: {} as Appointment,
        chapter: 0,
        subjectId: '',
        startClass: 0,
        endClass: 0,
        leaveFromFederalBooksListAt: new Date(),
    });

    const [authors, setAuthors] = useState<Author[]>([]);
    const [editors, setEditors] = useState<Editor[]>([]);
    const [subjects, setSubjects] = useState<Subject[]>([]);
    const [searchTerm, setSearchTerm] = useState('');
    const [loading, setLoading] = useState(false);
    const [options, setOptions] = useState<string[]>([]);
    const [inputValue, setInputValue] = useState<string>('');
    const [selectedItems, setSelectedItems] = useState<string[]>([]);

    const fetchAuthors = async (term: string) => {
        setLoading(true);
        const response = await new Promise<Author[]>((resolve) => {
            setTimeout(() => {
                const allAuthors: Author[] = [
                    { id: '1', fullName: 'Автор 1' },
                    { id: '2', fullName: 'Автор 2' },
                    { id: '3', fullName: 'Автор 3' },
                ];
                resolve(allAuthors.filter(author => author.fullName.toLowerCase().includes(term.toLowerCase())));
            }, 500);
        });
        setAuthors(response);
        setLoading(false);
    };

    const fetchEditors = async (term: string) => {
        setLoading(true);
        const response = await new Promise<Editor[]>((resolve) => {
            setTimeout(() => {
                const allEditors: Editor[] = [
                    { id: '1', fullName: 'Редактор 1' },
                    { id: '2', fullName: 'Редактор 2' },
                ];
                resolve(allEditors.filter(editor => editor.fullName.toLowerCase().includes(term.toLowerCase())));
            }, 500);
        });
        setEditors(response);
        setLoading(false);
    };

    const fetchSubjects = async (term: string) => {
        setLoading(true);
        const response = await new Promise<Subject[]>((resolve) => {
            setTimeout(() => {
                const allSubjects: Subject[] = [
                    { id: '1', name: 'Предмет 1' },
                    { id: '2', name: 'Предмет 2' },
                ];
                resolve(allSubjects.filter(subject => subject.name.toLowerCase().includes(term.toLowerCase())));
            }, 500);
        });
        setSubjects(response);
        setLoading(false);
    };

    useEffect(() => {
        if (searchTerm.length >= 3) {
            fetchAuthors(searchTerm);
            fetchEditors(searchTerm);
            fetchSubjects(searchTerm);
        } else {
            setAuthors([]);
            setEditors([]);
            setSubjects([]);
        }
    }, [searchTerm]);

    const handleSelectAuthor = (author: Author | null) => {
        if (author && !formData.authorIds.includes(author.id)) {
            setFormData(prev => ({
                ...prev,
                authorIds: [...prev.authorIds, author.id],
            }));
            setSearchTerm('');
        }
    };

    const handleDeleteAuthor = (authorId: string) => {
        setFormData(prev => ({
            ...prev,
            authorIds: prev.authorIds.filter(id => id !== authorId),
        }));
    };

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const fetchOptions = (value: string) => {
        setLoading(true);
        setTimeout(() => {
          const allOptions = ['Пушкин А.С.', 'Banana', 'Cherry', 'Date', 'Fig', 'Grape'];
          const filteredOptions = allOptions.filter(option =>
            option.toLowerCase().includes(value.toLowerCase())
          );
          setOptions(filteredOptions);
          setLoading(false);
        }, 1000);
    };

    const handleAddItem = () => {
        if (inputValue && !selectedItems.includes(inputValue)) {
            setSelectedItems(prev => [...prev, inputValue]);
            setInputValue('');
        }
    };

    const isButtonDisabled = !inputValue || selectedItems.includes(inputValue);

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Создать книжку</DialogTitle>
            <DialogContent>
                <Autocomplete
                    options={authors}
                    getOptionLabel={(option) => option.fullName}
                    loading={loading}
                    onInputChange={(event, value) => setSearchTerm(value)}
                    onChange={(event, value) => handleSelectAuthor(value)}
                    renderInput={(params) => (
                        <TextField {...params} label="Автор" margin="dense" fullWidth required />
                    )}
                />

                <Autocomplete
                        freeSolo
                        options={options}
                        loading={loading}
                        onInputChange={(event, newInputValue) => {
                                setInputValue(newInputValue);
                                if (newInputValue) {
                                    fetchOptions(newInputValue);
                                } else {
                                    setOptions([]);
                                }
                            }
                        }
                        renderInput={(params) => {
                            return (
                                <TextField
                                    {...params}
                                    label="Другие авторы"
                                    variant="outlined"
                                    InputProps={{
                                        ...params.InputProps,
                                        endAdornment: (
                                            <>
                                                {loading ? <CircularProgress size={20} /> : null}
                                                <IconButton
                                                    onClick={handleAddItem}
                                                    size="small"
                                                    disabled={isButtonDisabled}
                                                >
                                                    <AddIcon />
                                                </IconButton>
                                            </>
                                        ),
                                    }} />
                            );
                        }}
                        value={inputValue}
                        onChange={(event, newValue) => {
                                setInputValue(newValue);
                            }
                        }
                    />

                <div style={{ marginTop: 16 }}>
                    {selectedItems.map((item, index) => (
                        <Chip 
                            key={index} 
                            label={item} 
                            onDelete={() => setSelectedItems(prev => prev.filter(i => i !== item))}
                            style={{ margin: '4px' }}
                        />
                    ))}
                </div>

                <Box display="flex" flexWrap="wrap" marginTop={1}>
                    {formData.authorIds.map(authorId => {
                        const author = authors.find(a => a.id === authorId);
                        return (
                            author && (
                                <Chip
                                    key={author.id}
                                    label={author.fullName}
                                    onDelete={() => handleDeleteAuthor(author.id)}
                                    style={{ margin: '4px' }}
                                />
                            )
                        );
                    })}
                </Box>
                <Autocomplete
                    options={editors}
                    getOptionLabel={(option) => option.fullName}
                    loading={loading}
                    onInputChange={(event, value) => setSearchTerm(value)}
                    onChange={(event, value) => setFormData(prev => ({ ...prev, editorId: value ? value.id : '' }))}
                    renderInput={(params) => (
                        <TextField {...params} label="Редактор" margin="dense" fullWidth required />
                    )}
                />
                <Autocomplete
                    options={subjects}
                    getOptionLabel={(option) => option.name}
                    loading={loading}
                    onInputChange={(event, value) => setSearchTerm(value)}
                    onChange={(event, value) => setFormData(prev => ({ ...prev, subjectId: value ? value.id : '' }))}
                    renderInput={(params) => (
                        <TextField {...params} label="Предмет" margin="dense" fullWidth required />
                    )}
                />
                <TextField
                    margin="dense"
                    label="Название"
                    name="title"
                    value={formData.title}
                    onChange={handleChange}
                    fullWidth
                    required
                />
                <TextField
                    margin="dense"
                    label="ID места публикации"
                    name="publishingPlaceId"
                    value={formData.publishingPlaceId}
                    onChange={handleChange}
                    fullWidth
                    required
                />
                <TextField
                    margin="dense"
                    label="ID издательства"
                    name="publishingHouseId"
                    value={formData.publishingHouseId}
                    onChange={handleChange}
                    fullWidth
                    required
                />
                <TextField
                    margin="dense"
                    label="Серия публикации"
                    name="publishingSeries"
                    type="number"
                    value={formData.publishingSeries}
                    onChange={handleChange}
                    fullWidth
                    required
                />
                <TextField
                    margin="dense"
                    label="Глава"
                    name="chapter"
                    type="number"
                    value={formData.chapter}
                    onChange={handleChange}
                    fullWidth
                />
                <TextField
                    margin="dense"
                    label="Класс начала"
                    name="startClass"
                    type="number"
                    value={formData.startClass}
                    onChange={handleChange}
                    fullWidth
                />
                <TextField
                    margin="dense"
                    label="Класс окончания"
                    name="endClass"
                    type="number"
                    value={formData.endClass}
                    onChange={handleChange}
                    fullWidth
                />
                <TextField
                    margin="dense"
                    label="Дата исключения из федерального списка"
                    type="date"
                    name="leaveFromFederalBooksListAt"
                    value={formData.leaveFromFederalBooksListAt.toISOString().split('T')[0]}
                    onChange={handleChange}
                    fullWidth
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">Отмена</Button>
                <Button onClick={onSubmit} color="primary">Далее</Button>
            </DialogActions>
        </Dialog>
    );
};

export default CreateBaseEdBookDialog;
