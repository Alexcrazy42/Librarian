import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface AppState {
    value: number;
    id: string;
}
  
const initialState: AppState = {
    value: 0,
    id: ''
};


const appSlice = createSlice({
    name: 'app',
    initialState,
    reducers: {
      increment: (state) => {
        state.value += 1;
      },
      decrement: (state) => {
        state.value -= 1;
      },
      set: (state, action: PayloadAction<number>) => {
        state.value = action.payload;
      },
      setId: (state, action: PayloadAction<string>) => {
        state.id = action.payload;
      }
    },
});
  
export const { increment, decrement, set, setId } = appSlice.actions;
export default appSlice.reducer;