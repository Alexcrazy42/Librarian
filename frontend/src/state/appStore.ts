import { configureStore } from '@reduxjs/toolkit';
import appReducer from '@state/appSlice';

const appStore = configureStore({
    reducer: {
      counter: appReducer,
    },
});

export type RootState = ReturnType<typeof appStore.getState>;
export type AppDispatch = typeof appStore.dispatch;

export default appStore;