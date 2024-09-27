import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface AppState {
    groundId: string;
    schoolId: string;
    librarianId: string;
    isMainLibrarian: boolean
}
  
const initialState: AppState = {
  groundId: '',
  schoolId: '',
  librarianId: '',
  isMainLibrarian: false
};


const appSlice = createSlice({
    name: 'app',
    initialState,
    reducers: {
      setGroundId: (state, action: PayloadAction<string>) => {
        state.groundId = action.payload;
      },
      setSchoolId: (state, action: PayloadAction<string>) => {
        state.schoolId = action.payload;
      },
      setLibrarianId: (state, action: PayloadAction<string>) => {
        state.librarianId = action.payload;
      },
      setIsMainLibrarian: (state, action: PayloadAction<string>) => {
        state.librarianId = action.payload;
      },
    },
});
  
export const { setGroundId, setSchoolId, setLibrarianId, setIsMainLibrarian } = appSlice.actions;
export default appSlice.reducer;