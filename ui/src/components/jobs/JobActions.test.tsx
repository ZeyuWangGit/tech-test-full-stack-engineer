import renderer, { ReactTestRenderer } from 'react-test-renderer';
import { JobActions } from './JobActions';



it('JobActions triggers onAccept and onDecline correctly', () => {
  const mockAccept = jest.fn();
  const mockDecline = jest.fn();

  const component = renderer.create(
    <JobActions price={100} onAccept={mockAccept} onDecline={mockDecline} />
  );

  const testInstance = component.root;
  
  // Assuming that the first button is Accept and the second one is Decline
  const acceptButton = testInstance.findAllByType('button')[0];
  const declineButton = testInstance.findAllByType('button')[1];
  
  // Simulate button clicks
  acceptButton.props.onClick();
  declineButton.props.onClick();
  
  // Check if the handlers were called
  expect(mockAccept).toHaveBeenCalled();
  expect(mockDecline).toHaveBeenCalled();
});


