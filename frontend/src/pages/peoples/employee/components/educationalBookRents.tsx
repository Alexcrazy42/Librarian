import { Card, CardContent, Typography } from "@mui/material";

const EducationalBookRents: React.FC = () => {
    return (
        <>
        <Card className="max-w-sm mx-auto shadow-lg rounded-lg">
            <CardContent className="p-6"> 
                <Typography variant="h5" component="div" className="font-bold mb-2 text-center">
                        Учебная литература на руках
                </Typography>
            </CardContent>
        </Card>
        </>
    )
}

export default EducationalBookRents;