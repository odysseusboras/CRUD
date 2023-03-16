

import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useRef, useState } from "react";
import Form from 'react-bootstrap/Form';
import CrudComponent from "../Components/CRUDComponent";
import { BASE_API } from "../Constant";


export function DegreeComponent() {
    const [rowData, setRowData] = useState([]);
    const [columnDefs, setColumnDefs] = useState([
        { field: 'name' },
    ]);

    const gridRef = useRef();


    useEffect(() => {
        fetch(`${BASE_API}/Degree`)
            .then((res) => res.json())
            .then((data) => {
                setRowData(data);
            })
            .catch((err) => {
                console.log(err.message);
            });
    }, []);


    function deleteAction(id: any) {
        return {
            url: `${BASE_API}/Degree`,
            options: {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ Id: id })
            }
        }

    }
    function createAction(selectedItem: any) {
        return {
            url: `${BASE_API}/Degree`,
            options: {
                method: 'POST',
                body: JSON.stringify(selectedItem),
                headers: {
                    'Content-type': 'application/json; charset=UTF-8',
                }
            }

        }
    }
    function updateAction(selectedItem: any) {
        return {
            url: `${BASE_API}/Degree`,
            options: {
                method: 'PUT',
                body: JSON.stringify(selectedItem),
                headers: {
                    'Content-type': 'application/json; charset=UTF-8',
                }
            }

        }
    }

    function itemForm(item: any) {
        return (
            <div>
                <Form.Group className="mb-3" controlId="formGroupFirstName">
                    <Form.Label required={true}>Name</Form.Label>
                    <Form.Control required={true} name="name" type="text" placeholder="Enter name" defaultValue={item?.name} />
                </Form.Group>
            </div>
        );
    }
    function initiateForm() {

    }


    return (
        <div >
            <CrudComponent
                gridRef={gridRef}
                rowData={rowData}
                columnDefs={columnDefs}
                itemForm={itemForm}
                deleteAction={deleteAction}
                createAction={createAction}
                updateAction={updateAction}
                initiateForm={initiateForm} />
        </div>
    );
}


