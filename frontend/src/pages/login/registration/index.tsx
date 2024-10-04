import React, { useState } from 'react';
import {
  TextField,
  Button,
  Accordion,
  AccordionSummary,
  AccordionDetails,
  Typography,
  List,
  ListItem,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
} from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import AddIcon from '@mui/icons-material/Add';
import { School, Venue } from '@interfaces/interfaces';




const Registration: React.FC = () => {
  const [schoolName, setSchoolName] = useState<string>('');
  const [venues, setVenues] = useState<Venue[]>([]);
  const [venueName, setVenueName] = useState<string>('');
  const [librarianName, setLibrarianName] = useState<string>('');
  const [classroomNumber, setClassroomNumber] = useState<string>('');
  const [classroomName, setClassroomName] = useState<string>('');
  const [subjectsCount, setSubjectsCount] = useState<number>(0);
  const [openLibrarianDialog, setOpenLibrarianDialog] = useState<boolean>(false);
  const [openVenueDialog, setOpenVenueDialog] = useState<boolean>(false);
  const [openClassroomDialog, setOpenClassroomDialog] = useState<boolean>(false);
  const [selectedVenueId, setSelectedVenueId] = useState<number | null>(null);
  const [selectedClassroomId, setSelectedClassroomId] = useState<number | null>(null);

  const handleAddVenue = () => {
    if (venueName) {
      setVenues([...venues, { id: Date.now(), name: venueName, librarians: [], classrooms: [] }]);
      setVenueName('');
    }
  };

  const handleOpenLibrarianDialog = (venueId: number) => {
    setSelectedVenueId(venueId);
    setOpenLibrarianDialog(true);
  };

  const handleOpenVenueDialog = (venueId: number) => {
    const venue = venues.find(v => v.id === venueId);
    if (venue) {
      setVenueName(venue.name);
      setSelectedVenueId(venueId);
      setOpenVenueDialog(true);
    }
  };

  const handleOpenClassroomDialog = (venueId: number) => {
    setSelectedVenueId(venueId);
    setOpenClassroomDialog(true);
  };

  const handleCloseLibrarianDialog = () => {
    setOpenLibrarianDialog(false);
    setLibrarianName('');
    setSelectedVenueId(null);
  };

  const handleCloseVenueDialog = () => {
    setOpenVenueDialog(false);
    setVenueName('');
    setSelectedVenueId(null);
  };

  const handleCloseClassroomDialog = () => {
    setOpenClassroomDialog(false);
    setClassroomNumber('');
    setClassroomName('');
    setSubjectsCount(0);
    setSelectedClassroomId(null);
  };

  const handleAddLibrarian = () => {
    if (librarianName && selectedVenueId !== null) {
      const updatedVenues = venues.map(venue =>
        venue.id === selectedVenueId
          ? { ...venue, librarians: [...venue.librarians, { id: Date.now(), name: librarianName }] }
          : venue
      );
      setVenues(updatedVenues);
      handleCloseLibrarianDialog();
    }
  };

  const handleAddClassroom = () => {
    if (classroomNumber && classroomName && subjectsCount >= 0 && selectedVenueId !== null) {
      const updatedVenues = venues.map(venue =>
        venue.id === selectedVenueId
          ? {
              ...venue,
              classrooms: [...venue.classrooms, { id: Date.now(), number: classroomNumber, name: classroomName, subjectsCount }],
            }
          : venue
      );
      setVenues(updatedVenues);
      handleCloseClassroomDialog();
    }
  };

  const handleDeleteLibrarian = (venueId: number, librarianId: number) => {
    const updatedVenues = venues.map(venue =>
      venue.id === venueId
        ? { ...venue, librarians: venue.librarians.filter(librarian => librarian.id !== librarianId) }
        : venue
    );
    setVenues(updatedVenues);
  };

  const handleDeleteVenue = (venueId: number) => {
    const updatedVenues = venues.filter(venue => venue.id !== venueId);
    setVenues(updatedVenues);
  };

  const handleDeleteClassroom = (venueId: number, classroomId: number) => {
    const updatedVenues = venues.map(venue =>
      venue.id === venueId
        ? { ...venue, classrooms: venue.classrooms.filter(classroom => classroom.id !== classroomId) }
        : venue
    );
    setVenues(updatedVenues);
  };

  const handleEditVenue = () => {
    if (venueName && selectedVenueId !== null) {
      const updatedVenues = venues.map(venue =>
        venue.id === selectedVenueId
          ? { ...venue, name: venueName }
          : venue
      );
      setVenues(updatedVenues);
      handleCloseVenueDialog();
    }
  };

  const handleSubmit = () => {
    const school: School = {
      id: Date.now(),
      name: schoolName,
      venues,
    };
    console.log(school); // Здесь можно сохранить данные о школе
    alert('Данные успешно сохранены!');
  };

  return (
    <div className="p-4">
      <h1>Информация о школе</h1>
      <TextField
        label="Название школы"
        value={schoolName}
        onChange={(e) => setSchoolName(e.target.value)}
        fullWidth
      />
      <h2>Площадки</h2>
      <TextField
        label="Название площадки"
        value={venueName}
        onChange={(e) => setVenueName(e.target.value)}
        fullWidth
      />
      <Button onClick={handleAddVenue} variant="contained" color="primary" startIcon={<AddIcon />}>
        Добавить площадку
      </Button>

      {venues.map((venue) => (
        <Accordion key={venue.id}>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls={`panel-${venue.id}-content`}
            id={`panel-${venue.id}-header`}
          >
            <Typography>{venue.name}</Typography>
            <Button color="error" onClick={() => handleDeleteVenue(venue.id)} startIcon={<DeleteIcon />}>
              Удалить
            </Button>
            <Button onClick={() => handleOpenVenueDialog(venue.id)} startIcon={<EditIcon />}>
              Изменить
            </Button>
          </AccordionSummary>
          <AccordionDetails>
            <div>
              <Button variant="contained" color="secondary" onClick={() => handleOpenLibrarianDialog(venue.id)} startIcon={<AddIcon />}>
                Добавить библиотекаря
              </Button>
              <Button variant="contained" color="secondary" onClick={() => handleOpenClassroomDialog(venue.id)} startIcon={<AddIcon />}>
                Добавить класс
              </Button>
              <List>
                {venue.classrooms.map(classroom => (
                  <ListItem key={classroom.id}>
                    {`Класс ${classroom.number} - ${classroom.name} (${classroom.subjectsCount} предметов)`}
                    <Button color="error" onClick={() => handleDeleteClassroom(venue.id, classroom.id)} startIcon={<DeleteIcon />}>
                      Удалить
                    </Button>
                  </ListItem>
                ))}
                {venue.librarians.map(librarian => (
                  <ListItem key={librarian.id}>
                    {librarian.name}
                    <Button color="error" onClick={() => handleDeleteLibrarian(venue.id, librarian.id)} startIcon={<DeleteIcon />}>
                      Удалить
                    </Button>
                  </ListItem>
                ))}
              </List>
            </div>
          </AccordionDetails>
        </Accordion>
      ))}

      <Button onClick={handleSubmit} variant="contained" color="success">Сохранить школу</Button>

      {/* Модальное окно для добавления библиотекаря */}
      <Dialog open={openLibrarianDialog} onClose={handleCloseLibrarianDialog}>
        <DialogTitle>Добавить библиотекаря</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            label="Имя библиотекаря"
            value={librarianName}
            onChange={(e) => setLibrarianName(e.target.value)}
            fullWidth
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseLibrarianDialog}>Отмена</Button>
          <Button onClick={handleAddLibrarian} color="primary">Добавить</Button>
        </DialogActions>
      </Dialog>

      {/* Модальное окно для изменения площадки */}
      <Dialog open={openVenueDialog} onClose={handleCloseVenueDialog}>
        <DialogTitle>Изменить площадку</DialogTitle>
        <DialogContent>
          <TextField
            label="Название площадки"
            value={venueName}
            onChange={(e) => setVenueName(e.target.value)}
            fullWidth
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseVenueDialog}>Отмена</Button>
          <Button onClick={handleEditVenue} color="primary">Сохранить</Button>
        </DialogActions>
      </Dialog>

      {/* Модальное окно для добавления класса */}
      <Dialog open={openClassroomDialog} onClose={handleCloseClassroomDialog}>
        <DialogTitle>Добавить класс</DialogTitle>
        <DialogContent>
          <TextField
            label="Номер класса"
            value={classroomNumber}
            onChange={(e) => setClassroomNumber(e.target.value)}
            fullWidth
          />
          <TextField
            label="Название класса"
            value={classroomName}
            onChange={(e) => setClassroomName(e.target.value)}
            fullWidth
          />
          <TextField
            type="number"
            label="Количество предметов"
            value={subjectsCount}
            onChange={(e) => setSubjectsCount(Number(e.target.value))}
            fullWidth
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseClassroomDialog}>Отмена</Button>
          <Button onClick={handleAddClassroom} color="primary">Добавить</Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default Registration;
