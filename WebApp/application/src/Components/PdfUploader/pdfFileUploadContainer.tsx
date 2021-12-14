import React, {FunctionComponent, ReactNode} from "react";

interface IPdfUploadContainerProps {
    onFileUploaded: (obj:object)  => void;
}



const PdfFileUploadContainer = (props : IPdfUploadContainerProps) => {
    
    let displayText = "Upload a PDF file to contribute to the search engine."
    return (<div> <input type="file"
                         name="Upload PDF file"
                         accept="application/pdf,application/vnd.ms-excel"/>
        <div className={"PdfDisplay"}>
            {displayText}
        </div>
    </div>)
} 

export default PdfFileUploadContainer;