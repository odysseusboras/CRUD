
import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useRef, useState } from "react";
import Form from 'react-bootstrap/Form';
import CrudComponent from "../Components/CRUDComponent";
import { BASE_API } from "../Constant";

export function CVComponent() {
    const [rowData, setRowData] = useState([]);
    const [columnDefs, setColumnDefs] = useState([
        { field: 'identifier' },
        { field: 'firstName' },
        { field: 'lastName' },
        { field: 'hasBlob' },
        { field: 'degreeName' },
        { field: 'email' },
        { field: 'mobile' }
    ]);

    const [degrees, setDegrees] = useState([]);
    const gridRef = useRef();
    const [selectedDegreeId, setSelectedDegreeId]: any = useState('');


    useEffect(() => {
        fetch(`${BASE_API}/CV`)
            .then((res) => res.json())
            .then((data) => {
                setRowData(data);
            })
            .catch((err) => {
                console.log(err.message);
            });
    }, []);
    useEffect(() => {
        fetch(`${BASE_API}/Degree`)
            .then((res) => res.json())
            .then((data) => {
                setDegrees(data);
            })
            .catch((err) => {
                console.log(err.message);
            });
    }, []);

    function deleteAction(id: any) {
        return {
            url: `${BASE_API}/CV`,
            options: {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ Id: id })
            }
        }

    }
    function createAction(selectedItem: any) {

        var data = new FormData();
        data.append('id', selectedItem.id)
        data.append('blob', selectedItem.blob)
        data.append('lastName', selectedItem.lastName)
        data.append('firstName', selectedItem.firstName)
        data.append('email', selectedItem.email)
        data.append('modile', selectedItem.modile)
        data.append('degreeId', selectedItem.degreeId)

        return {
            url: `${BASE_API}/CV`,
            options: {
                method: 'POST',
                body: data,

            }

        }
    }
    function updateAction(selectedItem: any) {
        var data = new FormData();
        data.append('blob', selectedItem.blob)

        return {
            url: `${BASE_API}/CV`,
            options: {
                method: 'PUT',
                body: JSON.stringify(selectedItem),
                headers: {
                    'Content-type': 'application/json; charset=UTF-8',
                }
            }

        }
    }

    function createSelectItems() {

        let items = [];
        items.push(<option key={-1}> </option>);
        for (let i = 0; i <= degrees.length; i++) {
            let degree: any = degrees[i];
            if (degree != undefined) {
                items.push(<option key={i} value={degree.id}>{degree.name}</option>);
            }
        }
        return items;
    }


    function initiateForm() {
        setSelectedDegreeId();
    }

    function itemForm(item: any) {

        return (
            <div>
                <Form.Group className="mb-3" controlId="formGroupFirstName">
                    <Form.Label required={true}>First Name</Form.Label>
                    <Form.Control required={true} name="firstName" type="text" placeholder="Enter first name" defaultValue={item?.firstName} />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formGroupLastName">
                    <Form.Label required={true}>Last Name</Form.Label>
                    <Form.Control required={true} name="lastName" type="text" placeholder="Enter last name" defaultValue={item?.lastName} />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formGroupEmail">
                    <Form.Label required={true} >Email</Form.Label>
                    <Form.Control required={true} name="email" type="email" placeholder="Enter email" defaultValue={item?.email} />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formGroupMobile">
                    <Form.Label >Mobile</Form.Label>
                    <Form.Control name="mobile" type="number" placeholder="Mobile" defaultValue={item?.mobile} />
                </Form.Group>
                <Form.Group className="mb-3" controlId="degreeId">
                    <Form.Label>Degree</Form.Label>
                    <Form.Control
                        as="select"
                        name="degreeId"
                        defaultValue={item?.degreeId}
                        value={selectedDegreeId ?? item?.degreeId}
                        onChange={e => {
                            setSelectedDegreeId(e.target.value);
                        }}
                    >
                        {createSelectItems()}


                    </Form.Control>
                    {(item == undefined) && <Form.Group className="mb-3" controlId="formGroupBlob">
                        <Form.Label >File</Form.Label>
                        <Form.Control name="blob" type="file" placeholder="File" />
                    </Form.Group>}
                </Form.Group>

            </div>
        );
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

