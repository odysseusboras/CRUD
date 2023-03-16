import React from 'react';
import './App.css';
import { Tabs, Tab } from '@material-ui/core';
import { TabPanel } from './Components/TabPanel';
import { HomeComponent } from './Pages/HomeComponent';
import { CVComponent } from './Pages/CVComponent';
import { DegreeComponent } from './Pages/DegreeComponent';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: any, newValue: React.SetStateAction<number>) => {
    setValue(newValue);
  };

  return (
    <div >
      <Tabs value={value} onChange={handleChange} className='tabs'>
        <Tab label="Info" />
        <Tab label="CVs" />
        <Tab label="Degrees" />
      </Tabs>
      <TabPanel value={value} index={0} className='tabPanel'>
        <HomeComponent />
      </TabPanel>
      <TabPanel value={value} index={1} className='tabPanel'>
        <CVComponent />
      </TabPanel>
      <TabPanel value={value} index={2} className='tabPanel'>
        <DegreeComponent />
      </TabPanel>
    </div>
  );
}

export default App;
