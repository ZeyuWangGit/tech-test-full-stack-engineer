import axios, { AxiosResponse } from 'axios';
import { JobStatus } from '../common/enums/JobStatus';

const requestHeaders = {
  "Content-Type": 'application/json',
  "Access-Control-Allow-Origin": '*',
};

const DATA_SERVICE_URL = process.env.REACT_APP_DATA_SERVICE_URL;
// const DATA_SERVICE_URL = "http://localhost:8080/api";

export interface Job {
  id: number;
  status: JobStatus;
  suburbName: string;
  postcode: string;
  categoryName: string;
  contactName: string;
  contactPhone: string;
  contactEmail: string;
  price: number;
  description: string;
  createdAt: string;
  updatedAt: string;
}

export interface GetJobParam {
  jobStatus: JobStatus
}

export const getJobs = async (param: GetJobParam): Promise<Job[]> => {
  const response: AxiosResponse<Job[]> = await axios.get(`${DATA_SERVICE_URL}/Jobs?JobStatus=${param.jobStatus}`, { headers: requestHeaders });
  return response.data;
};

export interface UpdateJobParam {
  job: Job;
}

export const updateJob = async (param: UpdateJobParam): Promise<boolean> => {
  const response: AxiosResponse = await axios.put(`${DATA_SERVICE_URL}/jobs/${param.job.id}`, param.job, { headers: requestHeaders });
  return response.status === 204;
};
