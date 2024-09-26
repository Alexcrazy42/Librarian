import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { increment, decrement, setId } from '@state/appSlice';
import { RootState } from '@state/appStore';
import styles from '../styles/index.scss'
import { Button, Card, CardContent, Typography, TextField, FormControlLabel, Checkbox, Radio, Select, MenuItem, Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';

const Home: React.FC = () => {
  // const count = useSelector((state: RootState) => state.counter.value);
  // const id = useSelector((state: RootState) => state.counter.id);
  // const dispatch = useDispatch();

  // function generateRandomString(length: number): string {
  //   const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  //   let result = '';
  
  //   for (let i = 0; i < length; i++) {
  //     const randomIndex = Math.floor(Math.random() * characters.length);
  //     result += characters[randomIndex];
  //   }
  
  //   return result;
  // }

  // interface MyDialogProps {
  //   open: boolean;
  //   onClose: () => void;
  // }

  // const MyDialog = ({ open: boolean, onClose: () => void }) => {
  //   return (
  //     <Dialog open={open} onClose={onClose}>
  //       <DialogTitle>Создание книжки</DialogTitle>
  //       <TextField label="Название:" variant="outlined" fullWidth />
  //       <TextField label="Автор:" variant="outlined" fullWidth />
  //       <DialogActions>
  //         <Button onClick={onClose} color="primary">Close</Button>
  //       </DialogActions>
  //     </Dialog>
  //   );
  // };

  //const [open, setOpen] = useState(true);

  return (
    <div>
      {/* <h1>Home Page</h1>
      <h2>Counter: {count}</h2>
      <h2>Id: {id}</h2>
      <button onClick={() => dispatch(increment())}>Increment</button>
      <button onClick={() => dispatch(decrement())}>Decrement</button>
      <button onClick={() => dispatch(setId(generateRandomString(5)))}>SetId</button> */}

      <div className="flex items-center justify-center min-h-screen bg-gray-100">
      <Card className="w-96 shadow-lg">
        <CardContent>

          <Typography variant="h5" component="div" className="text-center mb-4">
            Welcome to My App!
          </Typography>

          <Typography variant="body2" color="text.secondary" className="text-center mb-6">
            This is a simple card using Material-UI and Tailwind CSS.
          </Typography>

          <Button variant="contained" color="primary">
            Нажми меня
          </Button>

          <TextField label="Фамилия:" variant="outlined" fullWidth />

          <FormControlLabel
            control={<Checkbox color="primary" />}
            label="Сдана книга"
          />

          <FormControlLabel
            control={<Radio />}
            label="Опция"
          />

          <Select defaultValue="" fullWidth>
            <MenuItem value={1}>Option 1</MenuItem>
            <MenuItem value={2}>Option 2</MenuItem>
          </Select>
        </CardContent>
      </Card>
    </div>
    </div>
  );
};

export default Home;