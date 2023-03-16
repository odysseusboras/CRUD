
import { ColDef } from "ag-grid-community";
import { AgGridReact } from "ag-grid-react";
import 'bootstrap/dist/css/bootstrap.min.css';
import { memo, useCallback, useState } from "react";
import Button from 'react-bootstrap/Button';
import toast, { Toaster } from "react-hot-toast";
import SlidingPane from "react-sliding-pane";
import "react-sliding-pane/dist/react-sliding-pane.css";
interface IProps {
    gridRef: any;
    rowData: any[];
    columnDefs: ColDef[];
    deleteAction: Function;
    itemForm: Function;
    createAction: Function;
    updateAction: Function;
    initiateForm: Function;
}


const CRUDComponent = ({ gridRef, rowData, columnDefs, deleteAction, itemForm: newItemForm, createAction, updateAction, initiateForm }: IProps) => {


    const [openPanel, setOpenPanel] = useState(false);
    const [existingItem, setExistingItem] = useState(false);
    const [data, setData] = useState({})


    function handleRequestOnError(error: any) {
        try {
            const erros = JSON.parse(error.message).errors;
            var errorMessage = "";
            Object.entries(erros).forEach(([key, value]) => {
                errorMessage += (value as []).join(',')
            });

            toast.error(errorMessage)
        }
        catch {
            let result = `error occured: ${error as string}`;
            toast.error(result);
        }
    }
    function handleRequestResponse(res: any) {
        if (!res.ok) {
            return res.text().then((text: string | undefined) => { throw new Error(text) })
        }
        else {
            return res.json();
        }
    }

    const onRemove = useCallback(() => {
        const selectedData = gridRef?.current?.api.getSelectedRows();

        if (selectedData.length == 0) {
            toast.error('Please select an item.')
            return;
        }
        var params = deleteAction(selectedData[0].id);
        fetch(params.url, params.options)
            .then(res => {
                return handleRequestResponse(res);
            })
            .then((data) => {
                toast.success('Deleted successfully')
                gridRef.current.api.applyTransaction({ remove: selectedData });
            })
            .catch((err) => {
                handleRequestOnError(err);
            });

    }, []);
    const onAdd = useCallback(() => {
        initiateForm();
        setExistingItem(false);
        setOpenPanel(true);
        setData({});
    }, []);
    const onEdit = useCallback(() => {
        initiateForm();
        const selectedData = gridRef?.current?.api.getSelectedRows();
        if (selectedData.length == 0) {
            toast.error('Please select an item.')
            return;
        }
        setData(selectedData[0])
        setExistingItem(true);
        setOpenPanel(true);
    }, []);

    const submit = (e: any) => {
        const formData = new FormData(e.target as HTMLFormElement);
        formData.forEach((value, key) => {

            if (key as any instanceof FormData) {
                (data as any)[key] = (e.target.blob as HTMLInputElement)?.files?.item(0);
            }
            else {
                (data as any)[key] = value;
            }
        });


        setData(data);

        e.preventDefault();
        var params;
        if (existingItem)
            params = updateAction(data);
        else
            params = createAction(data);


        fetch(params.url, params.options)
            .then(res => {
                return handleRequestResponse(res);
            })
            .then((data) => {
                if (existingItem) {

                    toast.success('Update successfully');
                    gridRef.current.api.applyTransaction({ update: [data] });
                }
                else {
                    toast.success('Created successfully');
                    gridRef.current.api.applyTransaction({ add: [data] });
                }
                setOpenPanel(false);
            })
            .catch((err) => {
                handleRequestOnError(err);
            });
    }

    function GetItemForm() {
        if (existingItem)
            return (<form onSubmit={submit}> {newItemForm(gridRef?.current?.api.getSelectedRows()[0])}  <Button className="btn-primary" variant="primary" type="submit" >Submit</Button> </form>);
        else
            return (<form onSubmit={submit}> {newItemForm()}  <Button className="btn-primary" variant="primary" type="submit" >Submit</Button> </form>);
    }

    function getRowId(params: { data: { id: any; }; }) {
        return params.data.id;
    }
    return (
        <>
            <div>
                <SlidingPane
                    className="some-custom-class"
                    overlayClassName="some-custom-overlay-class"
                    isOpen={openPanel}
                    title={!existingItem ? "Add new item" : "Edit item"}
                    onRequestClose={() => {
                        setOpenPanel(false);
                    }} >
                    <div>
                        {GetItemForm()}
                    </div>
                </SlidingPane>
            </div>
            <div>
                <div><Toaster /> </div>

                <div style={{ marginBottom: '4px' }}>
                    <Button className="btn-primary" variant="primary" onClick={onAdd} >Add New</Button>{' '}
                    <Button className="btn-primary" variant="primary" onClick={onEdit} >Edit</Button>{' '}
                    <Button className="btn-primary" variant="primary" onClick={onRemove} >Remove Selected</Button>{' '}
                </div>
                <div className="ag-theme-material" style={{ height: '500px' }}>
                    <AgGridReact
                        getRowId={getRowId}
                        ref={gridRef}
                        rowData={rowData}
                        columnDefs={columnDefs}
                        rowSelection={'single'}>
                    </AgGridReact></div>
            </div>

        </>
    )
}

export default memo(CRUDComponent)

function useForm(): { register: any; getValues: any; } {
    throw new Error("Function not implemented.");
}
