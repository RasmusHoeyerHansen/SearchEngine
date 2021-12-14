export interface IUploadFormProps {
    onFileUploaded: (obj:object)  => void;
}

export const PdfUploadForm = (props : IUploadFormProps) =>
{
    return (
        <input type="file"
               name="Upload PDF file"
               accept="application/pdf,application/vnd.ms-excel"
               multiple={true}
               onChange={props.onFileUploaded}/>
    );
}

