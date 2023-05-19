import React from 'react';
import { Row, Col } from 'antd';
import { GrLocation } from "react-icons/gr";
import { BiBriefcase } from "react-icons/bi";

interface JobDetailProps {
  id: number;
  location: string;
  postcode: string;
  jobType: string;
  price?: number;
}

export const JobDetail: React.FC<JobDetailProps> = ({ id, location, postcode, jobType, price }) => {
  return (
    <Row>
      <Col span={4}>
        <GrLocation /> {location} {postcode}
      </Col>
      <Col span={3}>
        <BiBriefcase /> 
        <span>{jobType}</span>
      </Col >
      <Col span={3}>
        Job ID: {id}
      </Col>
      {price && (
        <Col span={5}>
          ${price.toFixed(2)} Lead Invitation
        </Col>
      )}
    </Row>
  );
};