import { useMutation, useQueryClient } from 'react-query';
import { updateJob } from '../JobService';
import { JobStatus } from '../../common/enums/JobStatus';

export const useUpdateJob = () => {
  const queryClient = useQueryClient();

  return useMutation(updateJob, {
    onSuccess: () => {
      // Invalidate and refetch
      queryClient.invalidateQueries(['jobs', JobStatus.Accepted]);
      queryClient.invalidateQueries(['jobs', JobStatus.New]);
    },
  });
};
