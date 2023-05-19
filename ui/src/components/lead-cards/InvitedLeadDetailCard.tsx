import React from "react";
import { Card, Space } from 'antd';
import { Job } from "../../services/JobService";
import { JobDescription } from "../jobs/JobDescriptions";
import { JobDetail } from "../jobs/JobDetails";
import { UserInfo } from "../user/UserInfo";
import { JobActions } from "../jobs/JobActions";
import styled from "styled-components";

interface PendingDetailCardProps {
  job: Job;
  onJobAccepted: (job: Job) => void;
  onJobDeclined: (job: Job) => void;
}

const StyledCard = styled(Card)`
  .ant-card-body {
    text-align: left;
  }
  border-radius: 0;
`;

export const InvitedDetailCard: React.FC<PendingDetailCardProps> = (params: PendingDetailCardProps) => {
  const { job, onJobAccepted, onJobDeclined } = params;

  return (
    <Space direction="vertical" size={0.5} style={{ display: 'flex' }}>
      <StyledCard>
        <UserInfo name={job.contactName} jobCreatedDateTime={job.createdAt} />
      </StyledCard>
      <StyledCard>
        <JobDetail
          id={job.id}
          location={job.suburbName}
          postcode={job.postcode}
          jobType={job.categoryName}
        />
      </StyledCard>
      <StyledCard>
        <JobDescription text={job.description} />
      </StyledCard>
      <StyledCard>
      <JobActions
          price={job.price}
          onAccept={() => onJobAccepted(job)}
          onDecline={() => onJobDeclined(job)}
        />
      </StyledCard>
    </Space>
  );
}