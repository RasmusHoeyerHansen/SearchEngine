import React, {ReactNode} from "react";

export default function PdfFileUploader(props: { children: ReactNode }) {
    return <div> <input type="file"
                        name="Upload PDF file"
                        accept="application/pdf,application/vnd.ms-excel"/>
    </div>;

}