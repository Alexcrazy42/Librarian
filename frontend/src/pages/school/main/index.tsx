import React, { useEffect, useState } from 'react';
import { Box } 
from '@mui/material';
import Sidebar from '@components/left_side_bar_with_classes';
import { Outlet, useNavigate } from 'react-router-dom';
import { Classroom, Employee } from '@interfaces/interfaces';
import { fetchClassroomsAsync, fetchEmployeesAsync } from '@services/services';


const Main: React.FC = () => {
  const navigate = useNavigate();

  const [classrooms, setClassrooms] = useState<Classroom[]>([]);

  const [employees, setEmployees] = useState<Employee[]>([]);

  const handleSelectClassroom = (classroom: Classroom) => {
    navigate(`class/${classroom.id}`);
  };

  const handleSelectEmployee = (employee: Employee) => {
    navigate(`employee/${employee.id}`);
  }

  useEffect(() => {
    fetchEmployeesAsync()
      .then(data => {
        setEmployees(data);
      })

    fetchClassroomsAsync()
      .then(data => {
        setClassrooms(data);
      });
  }, []);


  return (
    <Box display="flex">
    <Box flex="0 0 12.5%" p={2}>
      <Sidebar
        classrooms={classrooms}
        employees={employees}
        onClassSelect={handleSelectClassroom}
        onEmployeeSelect={handleSelectEmployee}
      />
    </Box>
    <Box flex="1" p={2}>
      <div className="p-4">
        <Outlet />
      </div>
    </Box>
  </Box>
  );
};

export default Main;