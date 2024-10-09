import { StrictMode } from 'react'
import App from './App'
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { Provider } from "react-redux";
import store from '@state/appStore';
import Main from '@pages/school/main/index';
import Login from '@pages/login/login/index'
import Registration from '@pages/login/registration/index';
import ClassList from '@pages/peoples/class_list';
import StudentPage from '@pages/peoples/student';
import EmployeePage from '@pages/peoples/employee';
import EdBooksList from '@pages/ed_books/ed_books_list';
import SupplyPage from '@pages/supplies/supply_page';
import ClassSubjectTree from '@pages/classSubjects';
import Test from '@pages/test';
import MyDialog from '@pages/test';

const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        path: '/',
        element: <Main />,
        children: [
          {
            path: 'class/:id',
            element: <ClassList />
          },
          {
            path: 'employee/:id',
            element: <EmployeePage />
          },
          {
            path: 'student/:id',
            element: <StudentPage />
          },
          
        ]
      },
      {
        path: '/login',
        element: <Login />,
      },
      {
        path: '/registration',
        element: <Registration />,
      },
      {
        path: '/ed-books',
        element: <EdBooksList />
      },
      {
        path: '/supplies',
        element: <SupplyPage />
      },
      {
        path: '/class-subjects',
        element: <ClassSubjectTree />
      },
      {
        path: '/test',
        element: <MyDialog />
      },
    ]
  }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </StrictMode>
);