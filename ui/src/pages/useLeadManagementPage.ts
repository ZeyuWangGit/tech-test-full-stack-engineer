import { useState, useEffect } from "react";
import { JobStatus } from "../common/enums/JobStatus";
import { Job } from "../services/JobService";
import { useGetJobs } from "../services/hooks/useGetJobs";
import { useUpdateJob } from "../services/hooks/useUpdateJob";

export const useLeadManagementPage = () => {
    const [acceptedJobs, setAcceptedJobs] = useState<Job[]>();
    const [invitedJobs, setInvitedJobs] = useState<Job[]>([]);
    const [isLoading, setIsLoading] = useState(true);
  
    const { data: invitedJobsData, isLoading: isLoadingInvitedJobs, refetch: refetchInvitedJobs } = useGetJobs(JobStatus.New);
    const { data: acceptedJobsData, isLoading: isLoadingAcceptedJobs, refetch: refetchAcceptedJobs } = useGetJobs(JobStatus.Accepted);
  
    const updateJobHook = useUpdateJob();
  
    const onJobAccepted = async (job: Job) => {
      await updateJobHook.mutateAsync({ job: { ...job, status: JobStatus.Accepted } as Job });
      refetchInvitedJobs();
      refetchAcceptedJobs();
    };
  
    const onJobDeclined = async (job: Job) => {
      await updateJobHook.mutateAsync({ job: { ...job, status: JobStatus.Declined } as Job });
      refetchInvitedJobs();
      refetchAcceptedJobs();
    };
  
    useEffect(() => {
      if (invitedJobsData) {
        setInvitedJobs(invitedJobsData);
      }
      if (acceptedJobsData) {
        setAcceptedJobs(acceptedJobsData);
      }
      setIsLoading(isLoadingInvitedJobs || isLoadingAcceptedJobs);
    }, [invitedJobsData, acceptedJobsData, isLoadingInvitedJobs, isLoadingAcceptedJobs]);
  
    return {
      acceptedJobs,
      invitedJobs,
      isLoading,
      onJobAccepted,
      onJobDeclined,
    };
  };