import { useQuery, UseQueryResult } from 'react-query';
import { JobStatus } from '../../common/enums/JobStatus';
import { Job, getJobs } from '../JobService';

export const useGetJobs = (jobStatus: JobStatus): UseQueryResult<Job[], Error> => {
  return useQuery<Job[], Error>(['jobs', jobStatus], () => getJobs({ jobStatus }));
};
