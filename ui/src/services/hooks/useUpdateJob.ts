import { useMutation, useQueryClient } from 'react-query';
import { updateJob } from '../JobService';

export const useUpdateJob = () => {
  const queryClient = useQueryClient();

  return useMutation(updateJob, {
    onSuccess: () => {
      // Invalidate and refetch
      queryClient.invalidateQueries('acceptedJobs');
      queryClient.invalidateQueries('invitedJobs');
    },
  });
};
