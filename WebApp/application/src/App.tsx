import './Components/PdfUploader/pdfFileUploadContainer'
import './App.css';
import PdfFileUploadContainer from "./Components/PdfUploader/pdfFileUploadContainer";

function App() {
    
    
    return (
      <PdfFileUploadContainer onFileUploaded={
        () =>   console.log()}/>
    );
}

export default App;
