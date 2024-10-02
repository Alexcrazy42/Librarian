import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { increment, decrement, setId } from '@state/appSlice';
import { RootState } from '@state/appStore';
import { Button, Card, CardContent, Typography, 
  TextField, FormControlLabel, Checkbox, Radio, 
  Select, MenuItem, Dialog, DialogTitle, 
  DialogContent, DialogActions, 
  Grid} 
from '@mui/material';
import Sidebar from '@components/left_side_bar_with_classes';
import Employee from '@pages/peoples/employee';

interface Classroom {
  id: number;
  number: string;
  name: string;
}

interface Employee {
  id: number;
  fullName: string;
}

const Main: React.FC = () => {
  const [classrooms, setClassrooms] = useState<Classroom[]>([
    { id: 1, number: '1', name: 'A' },
    { id: 2, number: '2', name: 'Б' },
    { id: 3, number: '3', name: 'В' },
    { id: 4, number: '4', name: 'Г' },
    { id: 5, number: '5', name: 'Д' },
    { id: 6, number: '6', name: 'Е' },
    { id: 7, number: '7', name: 'Ё' },
    { id: 8, number: '8', name: 'Ж' },
    { id: 9, number: '9', name: 'З' },
    { id: 10, number: '10', name: 'И' },
    { id: 11, number: '11', name: 'К' },
  ]);

  const [employees, setEmployees] = useState<Employee[]>([
    { id: 1, fullName: 'Иван Иванов' },
    { id: 2, fullName: 'Мария Петрова' },
    { id: 3, fullName: 'Сергей Сидоров' },
    { id: 4, fullName: 'Анна Кузнецова' },
    { id: 5, fullName: 'Дмитрий Смирнов' },
    { id: 6, fullName: 'Екатерина Федорова' },
    { id: 7, fullName: 'Алексей Попов' },
    { id: 8, fullName: 'Ольга Васильева' },
    { id: 9, fullName: 'Николай Николаев' },
    { id: 10, fullName: 'Татьяна Романова' },
  ]);

  const handleSelectClassroom = (classroom: Classroom) => {
    console.log('Выбранный класс:', classroom);
  };

  const handleSelectEmployee = (employee: Employee) => {
    
  }


  return (
    <Grid container>
      <Grid item xs={1}>
        <Sidebar classrooms={classrooms} employees={employees} onClassSelect={handleSelectClassroom} onEmployeeSelect={handleSelectEmployee} />
      </Grid>
      <Grid item xs={9}>
        <div className="p-4">
          
        </div>
      </Grid>
    </Grid>
  );
};

export default Main;