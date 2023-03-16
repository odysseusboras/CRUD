


export function HomeComponent() {
    return (
        <div>
            <h1><b>CREATE, READ, UPDATE and DELETE</b></h1>

            <i>CRUD is the acronym for CREATE, READ, UPDATE and DELETE. These terms describe the four essential operations for creating and managing persistent data elements.</i>

            <br></br>
            <div>From this application you can CRUD degrees and CVs. You can connect CV to degree and upload a file for each record. </div>
            <br></br>
            <b>Technical Specifications</b>
            <ul>
                <li>Back End</li>
                <ol>
                    <li>.NET standard 7</li>
                    <li>Mediator</li>
                    <li>Fluent Migration</li>
                    <li>Entity Framework</li>
                </ol>
                <li>Front End</li>
                <ol>
                    <li>React</li>
                </ol>
            </ul>
            <br></br>
            <b>Configuration</b>
            <ul>
                <li>Back End</li>
                <ol>
                    <li>Define the connection string in the appsettings.json</li>
                    <li>Define the front end url for CORS</li>
                </ol>
                <li>Front End</li>
                <ol>
                    <li>Define the back end url for CRUD operations</li>
                </ol>
            </ul>

            <br></br>

            <video>
                <source src="./video//video-example.mp4" type="video/mp4" />
                Sorry, your browser doesn't support videos.
            </video>
        </div>
    );
}