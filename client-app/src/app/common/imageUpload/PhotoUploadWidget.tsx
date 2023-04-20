import { Grid, Header, Image } from "semantic-ui-react";
import PhotoWidgetDropzone from "./PhotoWidgetDropzone";
import { useState } from "react";

export default function PhotoUploadWidget() {
    const [files, setFiles] = useState<any>([]);
    return (
        <Grid>
            <Grid.Column width={4}>
                <Header sub color="blue" content='Step 1 - Add photo' />
                <PhotoWidgetDropzone setFiles={setFiles}/>
            </Grid.Column>
            <Grid.Column width={1} />
            <Grid.Column width={4}>
                <Header sub color="blue" content='Step 2 - Resize image' />
                {files && files.length > 0 && (
                    <Image src={files[0].preview} />
                )}
            </Grid.Column>
            <Grid.Column width={1} />
            <Grid.Column width={4}>
                <Header sub color="blue" content='Step 3 - Preview and upload' />
            </Grid.Column>
        </Grid>
    )
}