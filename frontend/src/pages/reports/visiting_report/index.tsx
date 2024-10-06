import { Button } from "@mui/material";

const VisitingReportPage = () => {
    return(
        <div className="flex flex-col justify-center items-center h-screen bg-gray-100 p-5">
            <h1 className="text-4xl font-bold mb-4">Отчет о проекте</h1>
            <p className="text-lg text-center mb-6">
                Пожалуйста, ознакомьтесь с отчетом о текущем состоянии проекта. 
                В документе содержится информация о достижениях, задачах и 
                дальнейших планах. Скачайте файл ниже, чтобы получить все детали.
            </p>
            <a href="/report.docx" download>
                <Button variant="contained" color="primary" className="mb-4">
                    Скачать отчет
                </Button>
            </a>
        </div>
    )
}

export default VisitingReportPage;