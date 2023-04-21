import Calendar from "react-calendar";
import { Menu, Header } from "semantic-ui-react";

export default function ActivityFilters() {
  return (
    <>
      <Menu vertical size="large" style={{ width: "100%", marginTop: 27 }}>
        <Header icon="filter" attached color="teal" content="Filters" />
        <Menu.Item content="All Events" />
        <Menu.Item content="I'm going" />
        <Menu.Item content="I'm hosting" />
      </Menu>
      <Header icon="calendar" attached color="teal" content="Select date" />
      <Calendar />
    </>
  );
}
