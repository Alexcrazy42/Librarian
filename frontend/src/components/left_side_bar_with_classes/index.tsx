import React, { useState } from 'react';
import { List, ListItem, ListItemText, Collapse, Button, Skeleton, ListItemIcon, IconButton } from '@mui/material';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import AddIcon from '@mui/icons-material/Add';
import CreateClassDialog from './components/createClassDialog';

interface SidebarProps {
  classrooms: Classroom[];
  employees: Employee[];
  onClassSelect: (classroom: Classroom) => void;
  onEmployeeSelect: (classroom: Employee) => void;
}

const Sidebar: React.FC<SidebarProps> = ({ classrooms, employees, onClassSelect, onEmployeeSelect }) => {
  const [classOpen, setClassOpen] = useState(false);
  const [employeeOpen, setEmployeeOpen] = useState(false);
  const [createClassDialogOpen, setCreateClassDialogOpen] = useState<boolean>(false);

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
        <List>
            <ListItem>
                <ListItemIcon>
                    <IconButton onClick={() => setCreateClassDialogOpen(true)}>
                        <AddIcon />
                    </IconButton>
                </ListItemIcon>
                {/* <ListItemText primary="Создать новый класс" /> */}
            </ListItem>
            {classrooms.length === 0 ? (
                Array.from({ length: 5 }).map((_, index) => (
                    <ListItem key={index}>
                        <ListItemText primary={<Skeleton width="200px" />} />
                    </ListItem>
                ))
            ) : (
                classrooms.map((classroom) => (
                    <ListItem button key={classroom.id} onClick={() => onClassSelect(classroom)}>
                        <ListItemText primary={`${classroom.number} ${classroom.name}`} />
                    </ListItem>
                ))
            )}
        </List>
    </Collapse>


      <Button onClick={handleEmployeeToggle} className="flex items-center">
        {employeeOpen ? <ExpandLess /> : <ExpandMore />}
        <span className="ml-2">Сотрудники</span>
      </Button>
      <Collapse in={employeeOpen} timeout="auto" unmountOnExit>
        <List>
              {employees.length === 0 ? (
                  Array.from({ length: 5 }).map((_, index) => (
                      <ListItem key={index}>
                          <ListItemText primary={<Skeleton width="200px" />} />
                      </ListItem>
                  ))
              ) : (
                employees.map((employee) => (
                      <ListItem button key={employee.id} onClick={() => onEmployeeSelect(employee)}>
                          <ListItemText primary={`${employee.fullName}`} />
                      </ListItem>
                  ))
              )}
          </List>
      </Collapse>

      <CreateClassDialog
          open={createClassDialogOpen}
          onClose={() => setCreateClassDialogOpen(false)}
      />
    </div>

    
  );
};

export default Sidebar;
