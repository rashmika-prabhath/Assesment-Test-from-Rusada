import { Box, Button, Grid } from '@mui/material';
import React, { useEffect, useState } from 'react'
import Swal from 'sweetalert2'
import axios from 'axios';
import { useRouter } from 'next/router';
import { DataGrid, GridColDef, GridValueGetterParams, GridToolbar } from '@mui/x-data-grid';
import { useDemoData } from '@mui/x-data-grid-generator';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import {
  DataGridPro,
  GridColumns,
  GridRowsProp,
  GridActionsCellItem,
} from '@mui/x-data-grid-pro';
import moment from 'moment';

const deleteRow = (id) => {
  Swal.fire({
    title: 'Do you want to delete the item?',
    showCancelButton: true,
    confirmButtonText: 'Delete',
    denyButtonText: `Don't Delete`,
  }).then((result) => {
    /* Read more about isConfirmed, isDenied below */
    if (result.isConfirmed) {
      axios.delete(`https://localhost:44319/api/AircraftSpot/${id}`)
        .then(({ data }) => {
          console.log("res", data);
          Swal.fire('Deleted!', '', 'success')
        })
        .catch(err => {
          console.log("err", err);
          Swal.fire(err?.message, '', 'error')
        })

    } else if (result.isDenied) {
      Swal.fire('Item is not deleted', '', 'info')
    }
  })
}

const columns: GridColDef[] = [
  { field: 'id', headerName: 'ID', width: 70 },
  {
    field: 'make',
    headerName: 'Make',
    width: 200,
    valueGetter: (params: GridValueGetterParams) =>
      `${params.row.aircraft.make || ''}`,
  },
  {
    field: 'model',
    headerName: 'Model',
    width: 200,
    valueGetter: (params: GridValueGetterParams) =>
      `${params.row.aircraft.model || ''}`,
  },
  {
    field: 'registration',
    headerName: 'Registration',
    width: 200,
    valueGetter: (params: GridValueGetterParams) =>
      `${params.row.aircraft.registration || ''}`,
  },
  { field: 'location', headerName: 'Location', width: 300 },
  {
    field: 'dateTime', headerName: 'Date & time', width: 300,
    valueGetter: (params: GridValueGetterParams) =>
      `${moment(params.row.dateTime).format('DD/MM/yyyy HH:mm') || ''}`,
  },
  {
    field: 'actions',
    type: 'actions',
    width: 100,
    getActions: (params: GridValueGetterParams) => [
      <GridActionsCellItem icon={<DeleteIcon />} label="Delete" onClick={e => (deleteRow(params.row.aircraft.id))} />,
    ],
  },
];



export const ListView = () => {
  const [aircraftSpots, setAircraftSpots] = useState([])
  const router = useRouter()
  useEffect(() => {
    axios.get(`https://localhost:44319/api/AircraftSpot/${router?.query?.id}`)
      .then(({ data }) => {
        console.log("res", data);
        setAircraftSpots(data)
      })
      .catch(err => {
        console.log("err", err);
        Swal.fire(err?.message, '', 'error')
      })
  }, [router?.query?.id])
  return (
    <div className="wrapper" style={{ 'marginTop': '50px' }}>
      <div className="container">
        <Grid container spacing={1} justifyContent="center">
          <div style={{ height: 400, width: '100%' }}>
            <Box>
              <h3>Aircraft Spotting List</h3>
              <Button onClick={e => router.push('/dashboard')}>Go to Dashboard</Button>
              <Button onClick={e => router.push(`/aircraft/add_spot?airCraftId=${router?.query?.id}`)}>Go to Create</Button>
            </Box>
            <DataGrid
              rows={aircraftSpots}
              columns={columns}
              pageSize={5}
              rowsPerPageOptions={[5]}
              components={{ Toolbar: GridToolbar }}
            />
          </div>
        </Grid>
      </div>
    </div>
  )
}
export default ListView;