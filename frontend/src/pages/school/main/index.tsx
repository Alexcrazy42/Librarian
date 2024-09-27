import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { increment, decrement, setId } from '@state/appSlice';
import { RootState } from '@state/appStore';
import { Button, Card, CardContent, Typography, 
  TextField, FormControlLabel, Checkbox, Radio, 
  Select, MenuItem, Dialog, DialogTitle, 
  DialogContent, DialogActions } 
from '@mui/material';

const Main: React.FC = () => {
  const enumMapping = {
    0: 'Внебюджетный',
    1: 'Общегородской'
  };

  const [selectedValue, setSelectedValue] = useState('');

  const handleChange = (event) => {
    setSelectedValue(event.target.value);
  };

  const handleSubmit = () => {
    const numericValue = parseInt(selectedValue, 10);
    // Здесь отправьте numericValue на бэкенд
    console.log('Отправка значения:', numericValue);
  };

  return (
    <div>
      
      <div className="flex items-center justify-center min-h-screen bg-gray-100">
        <Card className="w-96 shadow-lg">
          <CardContent>

            <Button 
              className="bg-blue-100 hover:bg-blue-700 mb-4"
              variant="outlined"
              color="primary"
            >
              Нажми меня
            </Button>

            <TextField className='mb-4' label="Фамилия:" variant="outlined" fullWidth />

            <FormControlLabel
              control={<Checkbox color="primary" />}
              label="Сдана книга"
              className='mb-4'
            />

            <FormControlLabel
              control={<Radio />}
              label="Опция"
              className='mb-4'
            />

            <Select
              labelId="select-label"
              value={selectedValue}
              onChange={handleChange}
              autoWidth
              className='mb-4'
            >
            {Object.entries(enumMapping).map(([key, value]) => (
              <MenuItem key={key} value={key}>
                {value}
              </MenuItem>
            ))}
            </Select>

          <Button onClick={handleSubmit} color="primary" variant="contained">
            Отправить
          </Button>

            {/* <MyDialog open={isModalOpen} onClose={() => setIsModalOpen(false)} ></MyDialog> */}
          </CardContent>
        </Card>
      </div>
    </div>
  );
};

export default Main;