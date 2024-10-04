import React, { Suspense, useState } from 'react';
import { List, ListItem, ListItemText, Typography, Collapse, Button } from '@mui/material';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import { useNavigate } from 'react-router-dom';
import { Classroom, Employee } from '@pages/school/main';

interface SidebarProps {
  classrooms: Classroom[];
  employees: Employee[];
  onClassSelect: (classroom: Classroom) => void;
  onEmployeeSelect: (classroom: Employee) => void;
}

const Sidebar: React.FC<SidebarProps> = ({ classrooms, employees, onClassSelect, onEmployeeSelect }) => {
  const [classOpen, setClassOpen] = useState(false);
  const [employeeOpen, setEmployeeOpen] = useState(false);

  const handleClassroomToggle = () => {
    setClassOpen(!classOpen);
  };

  const handleEmployeeToggle = () => {
    setEmployeeOpen(!employeeOpen);
  }


  return (
    <div className="h-full w- bg-gray-200 border-l-4 border-blue-500 p-4 shadow-md">
      <Button onClick={handleClassroomToggle} className="flex items-center">
        {classOpen ? <ExpandLess /> : <ExpandMore />}
        <span className="ml-2">Классы</span>
      </Button>
      <Collapse in={classOpen} timeout="auto" unmountOnExit>
          <List component="div" disablePadding>
            {classrooms.map((classroom) => (
              <ListItem button key={classroom.id} onClick={() => onClassSelect(classroom)}>
                <ListItemText primary={`${classroom.number} ${classroom.name}`} />
              </ListItem>
            ))}
          </List>
      </Collapse>


      <Button onClick={handleEmployeeToggle} className="flex items-center">
        {employeeOpen ? <ExpandLess /> : <ExpandMore />}
        <span className="ml-2">Сотрудники</span>
      </Button>
      <Collapse in={employeeOpen} timeout="auto" unmountOnExit>
        <List component="div" disablePadding>
          {employees.map((employee) => (
            <ListItem button key={employee.id} onClick={() => onEmployeeSelect(employee)}>
              <ListItemText primary={`${employee.fullName}`} />
            </ListItem>
          ))}
        </List>
      </Collapse>
    </div>
  );
};

export default Sidebar;
