import React from 'react';
import { PhoneOutlined, MailOutlined } from '@ant-design/icons';
import styled from 'styled-components';

interface ContactProps {
  telephone: string;
  email: string;
}

const StyledContactDetail = styled.a`
  color: rgb(247, 135, 16);
  font-weight: bold;
  padding-right: 16px;
  text-decoration: none !important;

  &:hover {
    color: rgb(247, 135, 16);
    font-weight: normal;
  }
`;

export const UserContactDetail: React.FC<ContactProps> = ({ telephone, email }) => {
  const emailLink = `mailto:${email}`;
  const teleLink = `tel:${telephone}`;

  return (
    <div>
      <PhoneOutlined />{' '}
      <StyledContactDetail href={teleLink}>{telephone}</StyledContactDetail>{' '}
      <MailOutlined />{' '}
      <StyledContactDetail href={emailLink}>{email}</StyledContactDetail>
    </div>
  );
};