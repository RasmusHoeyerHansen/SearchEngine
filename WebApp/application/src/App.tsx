import './Components/PdfUploader/pdfUploadContainer'
import './App.css';
import PdfUploadContainer from "./Components/PdfUploader/pdfUploadContainer";

function App() {
    
    
    return (
      <PdfUploadContainer onFileUploaded={
        () =>   console.log()}/>
    );
}

export default App;
