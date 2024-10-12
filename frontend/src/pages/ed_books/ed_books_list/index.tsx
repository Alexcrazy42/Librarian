import { EdBookInBalanceResponse } from "@interfaces/responses/edBooksResponses";
import EdBookTable from "./components/booksPage";
import Filters from "./components/filters";
import { Box, Button, Fab } from "@mui/material";
import { useState } from "react";
import AddIcon from '@mui/icons-material/Add';
import CreateEdBookDialog from "./components/createBaseEdBookDialog";
import CreateEdBookInBalanceDialog from "./components/createEdBookInBalanceDialog";

const languages = ['Английский', 'Французский', 'Испанский', 'Немецкий', 'Русский'];
const levels = ['Начальный', 'Средний', 'Продвинутый'];
const appointments = ['Общий', 'Специальный', 'Продвинутый'];
const conditions = ['Новый', 'Б/у', 'Восстановленный'];

const generateData = (count: number): EdBookInBalanceResponse[] => {
    const data: EdBookInBalanceResponse[] = [];
  
    for (let i = 1; i <= count; i++) {
      const baseEdBook = {
        id: `book-${i}`,
        title: `Book ${i}`,
        publishingSeries: i % 10,
        language: languages[i % languages.length],
        level: levels[i % levels.length],
        appointment: appointments[i % appointments.length],
        chapter: i % 5,
        startClass: i % 5 + 1,
        endClass: i % 5 + 5,
      };
  
      const edBook = {
        id: `edbook-${i}`,
        baseEdBook,
        price: i * 10,
        condition: conditions[i % conditions.length],
        year: 2020 + i % 5,
        note: `Note ${i}`,
        inPlaceCount: i % 10,
        totalCount: i % 20,
        supplyId: `supply-${i}`,
        groundId: `ground-${i}`,
        inStock: i % 2 === 0,
      };
  
      data.push(edBook);
    }
  
    return data;
  };

const EdBooksList = () => {
    const data: EdBookInBalanceResponse[] = generateData(100);
    const [createBaseEdBookDialogOpen, setCreateBaseEdBookDialogOpen] = useState<boolean>(false);
    const [createEdBookInBalanceDialogOpen, setCreateEdBookInBalanceDialogOpen] = useState<boolean>(false);
    const [searchTerm, setSearchTerm] = useState<string>('');
    
    const handleBaseEdBookDialogClose = () => setCreateBaseEdBookDialogOpen(false);

    const handleBaseEdBookDialogSubmit = () => {
      setCreateBaseEdBookDialogOpen(false);
      setCreateEdBookInBalanceDialogOpen(true);
    }

    const handleEdBookInBalanceDialogClose = () => setCreateEdBookInBalanceDialogOpen(false);
    
    return (
        <>
            <Box display="flex" justifyContent="space-between" alignItems="center" mt={2} mb={2}>
                
                <Filters searchTerm={searchTerm} setSearchTerm={setSearchTerm} />

                <Fab color="primary" 
                    aria-label="add" 
                    onClick={() => setCreateBaseEdBookDialogOpen(true)}>
                    <AddIcon />
                </Fab>
            </Box>
            
            <EdBookTable data={data} />

            <CreateEdBookDialog
                open={createBaseEdBookDialogOpen}
                onClose={handleBaseEdBookDialogClose}
                onSubmit={handleBaseEdBookDialogSubmit}
            />

            <CreateEdBookInBalanceDialog
              open={createEdBookInBalanceDialogOpen}
              onClose={handleEdBookInBalanceDialogClose}
            />
        </>
    );
}

export default EdBooksList;