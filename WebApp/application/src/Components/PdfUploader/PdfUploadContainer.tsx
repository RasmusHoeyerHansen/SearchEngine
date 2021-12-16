import {IUploadFormProps, PdfUploadForm} from "./UploadForm";
import {ChangeEvent, FormEvent, useState} from "react";


export interface IPdfUploadContainerProps extends IUploadFormProps{

}

export const PdfUploadContainer = () => {

    const [pdfFiles, setState] = useState<File[]>()
    const [count, setCountState] = useState(0);
    
    let displayText = "Upload a PDF file to contribute to the search engine."

    
    const onFileSelectionChanged = (event: ChangeEvent<HTMLInputElement>) => {
        let selectedFiles :File[] = [];

        const element = event.currentTarget as HTMLInputElement;
        
        let fileList: FileList | null = element.files;
        if (fileList) {
            for (let itm in fileList)
            {
                let item: File = fileList[itm];
                if (!selectedFiles.includes(item))
                    selectedFiles.push(item);
            }
        }
        
        setState(selectedFiles);
        setCountState(selectedFiles.length)
    }
    
    
    return (<div className={"PdfUploadContainer"}>
        <PdfUploadForm onChange={onFileSelectionChanged}/>    
        <div>
            {pdfFiles?.length}
        </div>
    </div>)
}

export default PdfUploadContainer;