import React from 'react';
import { Card, Space } from 'antd';
import styled from 'styled-components';
import { UserInfo } from '../user/UserInfo';
import { JobDetail } from '../jobs/JobDetails';
import { UserContactDetail } from '../user/UserContactDetail';
import { JobDescription } from '../jobs/JobDescriptions';

interface Job {
  id: number;
  price: number;
  suburbName: string;
  postcode: string;
  categoryName: string;
  contactName: string;
  createdAt: string;
  contactPhone: string;
  contactEmail: string;
  description: string;
}

interface AcceptedDetailCardProps {
  job: Job;
}

const StyledCard = styled(Card)`
  .ant-card-body {
    text-align: left;
  }
  border-radius: 0;
`;

export const AcceptedLeadDetailCard: React.FC<AcceptedDetailCardProps> = ({ job }) => {
  return (
    <Space direction="vertical" size={0.5} style={{ display: 'flex' }}>
      <StyledCard>
        <UserInfo name={job.contactName} jobCreatedDateTime={job.createdAt} />
      </StyledCard>
      <StyledCard>
        <JobDetail
          id={job.id}
          price={job.price}
          location={job.suburbName}
          postcode={job.postcode}
          jobType={job.categoryName}
        />
      </StyledCard>
      <StyledCard>
        <UserContactDetail telephone={job.contactPhone} email={job.contactEmail} />
        <JobDescription text={job.description} />
      </StyledCard>
    </Space>
  );
};