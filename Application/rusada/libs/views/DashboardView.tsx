import React from 'react'
import { Button, Grid } from '@mui/material'
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import AircraftList from './AircraftList';
import AircraftRegistration from './AircraftRegistration';
import Modal from '@mui/material/Modal';
interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `simple-tab-${index}`,
    'aria-controls': `simple-tabpanel-${index}`,
  };
}

export default function DashboardView() {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setValue(newValue);
  };
  return (
    <div className="wrapper">
      <div className="container">
        <Grid container spacing={2} m={5}>
          <Box sx={{ width: '100%' }}>
            <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
              <Tabs value={value} onChange={handleChange} aria-label="basic tabs example">
                <Tab label="List of Aircrafts" {...a11yProps(0)} />
                <Tab label="Add new Aircraft" {...a11yProps(1)} />
              </Tabs>
            </Box>
            <TabPanel value={value as any} index={0}>
              <AircraftList />
            </TabPanel>
            <TabPanel value={value as any} index={1}>
              <AircraftRegistration />
            </TabPanel>
          </Box>
        </Grid>
      </div>
    </div>
  )
}
