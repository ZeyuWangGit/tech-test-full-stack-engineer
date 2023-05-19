import { format } from 'date-fns';

function getJobCreatedDateTimeString(date: string | number | Date): string {
  const dateObject = new Date(date);
  return format(dateObject, "MMMM d '@' h:mm a");
}

export default getJobCreatedDateTimeString;
