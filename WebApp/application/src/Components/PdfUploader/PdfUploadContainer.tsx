import {IUploadFormProps, PdfUploadForm} from "./UploadForm";


export interface IPdfUploadContainerProps extends IUploadFormProps{

}



export const PdfUploadContainer = (props : IPdfUploadContainerProps) => {
    let displayText = "Upload a PDF file to contribute to the search engine."
    
    return (<div className={"PdfUploadContainer"}>
        <PdfUploadForm onFileUploaded={props.onFileUploaded}/>    
        <div>
            {displayText}
        </div>
    </div>)
}

export default PdfUploadContainer;