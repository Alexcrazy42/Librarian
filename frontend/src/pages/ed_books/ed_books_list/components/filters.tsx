import React from 'react';
import { TextField } from '@mui/material';

interface FiltersProps {
    searchTerm: string;
    setSearchTerm: (value: string) => void; // Изменено на прием строки
}

const Filters: React.FC<FiltersProps> = ({ searchTerm, setSearchTerm }) => {
    return (
        <TextField
            label="Поиск книги"
            variant="outlined"
            fullWidth
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            margin="normal"
        />
    );
};

export default Filters;